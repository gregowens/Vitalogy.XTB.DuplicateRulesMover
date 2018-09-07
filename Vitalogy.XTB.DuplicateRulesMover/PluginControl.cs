using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;

namespace Vitalogy.XTB.DuplicateRulesMover
{
    public partial class PluginControl : MultipleConnectionsPluginControlBase, IGitHubPlugin, IHelpPlugin, IStatusBarMessenger
    {
        #region Variables

        private int _currentsColumnOrder;
        private readonly DupeRulesManager _drManager;

        #endregion Variables

        #region Constructor

        public PluginControl()
        {
            InitializeComponent();
            _drManager = new DupeRulesManager();
        }

        #endregion Constructor

        #region XrmToolbox

        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;

        public string HelpUrl => "https://github.com/gregowens/Vitalogy.XTB.DuplicateRulesMover/wiki";
        public string RepositoryName => "Vitalogy.XTB.DuplicateRulesMover";
        public string UserName => "gregowens";

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName = "", object parameter = null)
        {
            ConnectionDetail = detail;
            if (actionName == "AdditionalOrganization")
            {
                AdditionalConnectionDetails.Clear();
                AdditionalConnectionDetails.Add(detail);
                SetConnectionLabel(detail, "Target");
            }
            else
            {
                SetConnectionLabel(detail, "Source");
            }

            base.UpdateConnection(newService, detail, actionName, parameter);
        }

        protected override void ConnectionDetailsUpdated(NotifyCollectionChangedEventArgs e)
        {
        }

        #endregion XrmToolbox

        #region UI Events

        private void BtnSelectTargetClick(object sender, EventArgs e)
        {
            AddAdditionalOrganization();
        }

        private void lvDedupeRules_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == _currentsColumnOrder)
            {
                lvDedupeRules.Sorting = lvDedupeRules.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;

                lvDedupeRules.ListViewItemSorter = new ListViewItemComparer(e.Column, lvDedupeRules.Sorting);
            }
            else
            {
                _currentsColumnOrder = e.Column;
                lvDedupeRules.ListViewItemSorter = new ListViewItemComparer(e.Column, SortOrder.Ascending);
            }
        }

        private void TsbLoadDedupeRulesClick(object sender, EventArgs e)
        {
            ExecuteMethod(RetrieveDedupeRules);
        }

        private void TsbTransferDupeRulesClick(object sender, EventArgs e)
        {
            if (lvDedupeRules.SelectedItems.Count > 0 && AdditionalConnectionDetails.Count > 0)
            {
                var selectedRules = lvDedupeRules.SelectedItems.Cast<ListViewItem>().Select(item => (IGrouping<Guid,Entity>)item.Tag).ToList();

                lbLogs.Items.Clear();
                tsbLoadDupeRules.Enabled = false;
                tsbTransferDupeRules.Enabled = false;
                btnSelectTarget.Enabled = false;
                Cursor = Cursors.WaitCursor;

                var worker = new BackgroundWorker();
                worker.DoWork += (s, evt) =>
                {
                    var selections = (List<IGrouping<Guid,Entity>>)evt.Argument;
                    var total = selections.Count;
                    var current = 0;
                    var targetService = AdditionalConnectionDetails.First().GetCrmServiceClient();

                    foreach (var ruleGroup in selections)
                    {
                        current++;                        

                        string name = ruleGroup.First().GetAttributeValue<string>("name");

                        SendMessageToStatusBar(this,
                            new StatusBarMessageEventArgs(current * 100 / total, "Processing rule '" + name + "'..."));

                        try
                        {
                            var ruleToTransfer = new Entity(ruleGroup.First().LogicalName);
                            foreach (var attribute in ruleGroup.First().Attributes)
                            {
                                // skip related condition records
                                if (!attribute.Key.StartsWith("condition."))
                                {
                                    ruleToTransfer[attribute.Key] = attribute.Value;
                                }
                            }

                            // Delete existing conditions (or delete entire rule)
                            Guid existingId = _drManager.DedupeRuleExists(targetService, name);
                            if (existingId != Guid.Empty)
                            {
                                ruleToTransfer["duplicateruleid"] = existingId;

                                targetService.Delete(ruleToTransfer.LogicalName, existingId);
                            }

                            existingId = targetService.Create(ruleToTransfer);
                            ruleToTransfer["duplicateruleid"] = existingId;

                            // iterate conditions and apply those
                            foreach (var condition in ruleGroup)
                            {
                                var dedupeCondition = new Entity("duplicaterulecondition")
                                {
                                    ["regardingobjectid"] =
                                        new EntityReference(ruleToTransfer.LogicalName, existingId)
                                };
                                foreach (var attribute in condition.Attributes)
                                {
                                    // only use related condition records
                                    if (attribute.Key.StartsWith("condition.") && !attribute.Key.EndsWith(".duplicateruleconditionid"))
                                    {
                                        dedupeCondition[attribute.Key.Replace("condition.",String.Empty)] = ((AliasedValue)attribute.Value).Value;
                                    }
                                }

                                targetService.Create(dedupeCondition);
                            }

                            // publish if source as also pubished
                            if (ruleGroup.First().GetAttributeValue<OptionSetValue>("statecode").Value == 1) // active
                            {
                                PublishDuplicateRuleRequest publishReq = new PublishDuplicateRuleRequest
                                    {DuplicateRuleId = existingId};
                                targetService.Execute(publishReq);
                            }

                            Log(name, true);
                        }
                        catch (Exception error)
                        {
                            Log(name, false, error.Message);
                        }
                    }
                
                };
                worker.ProgressChanged += (s, evt) =>
                {
                    SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(0, evt.UserState.ToString()));
                };
                worker.RunWorkerCompleted += (s, evt) =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(ParentForm, @"An error has occured while transferring dedupe rules: " + evt.Error.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    tsbLoadDupeRules.Enabled = true;
                    tsbTransferDupeRules.Enabled = true;
                    btnSelectTarget.Enabled = true;
                    Cursor = Cursors.Default;

                    SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(string.Empty));
                };
                worker.WorkerReportsProgress = true;
                worker.RunWorkerAsync(selectedRules);
            }
            else
            {
                MessageBox.Show(@"You have to select at least one source dedupe rule and a target organisation to continue.", @"Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion UI Events

        #region Methods

        private void Log(string name, bool succeeded, string message = null)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    lbLogs.Items.Add(
                        $"{(succeeded ? "Success" : "Error")}: {name}{(message != null ? " : " + message : "")}");
                });
            }
        }

        /// <summary>
        /// Retrieves dedupe rules from the source organization
        /// </summary>
        private void RetrieveDedupeRules()
        {
            lvDedupeRules.Items.Clear();

            tsbLoadDupeRules.Enabled = false;
            tsbTransferDupeRules.Enabled = false;
            btnSelectTarget.Enabled = false;
            Cursor = Cursors.WaitCursor;

            SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Loading dedupe rules..."));

            var bw = new BackgroundWorker();
            bw.DoWork += (sender, e) =>
            {
                e.Result = _drManager.GetDedupeRules(Service);
            };
            bw.RunWorkerCompleted += (sender, e) =>
            {
                if (e.Error == null)
                {
                    //var distinctRules = ((List<Entity>) e.Result).DistinctBy(rule => rule.GetAttributeValue<string>("name"));
                    var distinctRules = ((List<Entity>) e.Result).GroupBy(x => x.Id);
                    foreach (var dedupeRule in distinctRules)
                    {
                        var item1 = new ListViewItem
                        {
                            Tag = dedupeRule, Text = dedupeRule.First().GetAttributeValue<string>("name"), ToolTipText = this.Text
                        };
                        item1.SubItems.Add(dedupeRule.First().GetAttributeValue<string>("baseentityname"));
                        item1.SubItems.Add(dedupeRule.First().GetAttributeValue<string>("matchingentityname"));
                        item1.SubItems.Add(dedupeRule.First().FormattedValues["statecode"]);

                        lvDedupeRules.Items.Add(item1);
                    }
                }
                else
                {
                    MessageBox.Show(ParentForm, @"An error has occured while loading dedupe rules: " + e.Error.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                tsbLoadDupeRules.Enabled = true;
                tsbTransferDupeRules.Enabled = true;
                btnSelectTarget.Enabled = true;
                Cursor = Cursors.Default;

                SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(string.Empty));
            };
            bw.RunWorkerAsync();
        }

        /// <summary>
        /// Sets the connections labels on either the source/target section
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="serviceType"></param>
        private void SetConnectionLabel(ConnectionDetail detail, string serviceType)
        {
            switch (serviceType)
            {
                case "Source":
                    lblSource.Text = detail.ConnectionName;
                    lblSource.ForeColor = Color.Green;
                    break;

                case "Target":
                    lblTarget.Text = detail.ConnectionName;
                    lblTarget.ForeColor = Color.Green;
                    break;
            }
        }

        #endregion Methods
    }
}