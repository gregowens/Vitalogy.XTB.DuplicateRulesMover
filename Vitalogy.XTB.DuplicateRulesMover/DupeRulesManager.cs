using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Vitalogy.XTB.DuplicateRulesMover
{
    internal class DupeRulesManager
    {
        public List<Entity> GetDedupeRules(IOrganizationService service)
        {
            var qe = new QueryExpression("duplicaterule") { ColumnSet = new ColumnSet("duplicateruleid", "name", "matchingentityname", "baseentityname", "description", "excludeinactiverecords", "iscasesensitive", "statecode") };
            //qe.Criteria.AddCondition("statecode", ConditionOperator.Equal, 1); // only published rules
            //Link to related table
            qe.LinkEntities.Add(new LinkEntity("duplicaterule", "duplicaterulecondition", "duplicateruleid", "regardingobjectid", JoinOperator.Inner));
            qe.LinkEntities[0].EntityAlias = "condition";
            qe.LinkEntities[0].Columns = new ColumnSet("baseattributename", "duplicateruleconditionid", "ignoreblankvalues", "matchingattributename", "operatorcode", "operatorparam");
            var results = service.RetrieveMultiple(qe);
            if (results?.Entities != null && results.Entities.Count > 0)
            {
                return results.Entities.ToList();
            }

            return new List<Entity>();
        }

        public Guid DedupeRuleExists(IOrganizationService service, string name)
        {
            var result = Guid.Empty;

            var qe = new QueryExpression("duplicaterule");
            qe.Criteria.AddCondition("name", ConditionOperator.Equal, name);

            var results = service.RetrieveMultiple(qe);
            if (results?.Entities != null && results.Entities.Count > 0)
            {
                result = results[0].Id;
            }

            return result;
        }
    }
}
