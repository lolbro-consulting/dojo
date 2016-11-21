using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{
    public class AssetSummaries
    {
        public IList<AssetSummary> assetSummary { get; set; }//getting deserialized value for assetSummary class.
        public override string ToString()
        {
            StringBuilder assetSummaries = new StringBuilder("");
            if (assetSummary == null)
                return assetSummaries.ToString();
            for (int i = 0; i < assetSummary.Count; i++)
            {
                string summaryValue = "NA";
                string summaryContribution = "NA";
                if (assetSummary[i].Contribution != null)
                {
                    summaryContribution = assetSummary[i].Contribution;
                }
                if (assetSummary[i].Value != null) {
                    summaryValue = assetSummary[i].Value.amount;
                }
                string value = "NA";
                string cash = "NA";
                if (assetSummary[i].Holding != null) {
                    for (int j = 0; j < assetSummary[i].Holding.Count(); j++) {
                        
                        if (assetSummary[i].Holding[j].Value!=null) {
                            value = assetSummary[i].Holding[j].Value.amount;
                        }
                        assetSummaries.Append(assetSummary[i].ClassificationType.PadRight(19, '-')).Append(assetSummary[i].ClassificationValue.PadRight(20, '-')).Append(summaryContribution.PadRight(12, '-')).Append(summaryValue.PadRight(8, '-')).Append(assetSummary[i].Holding[j].Id.PadRight(8,'-')).Append(assetSummary[i].Holding[j].AccountId.PadRight(11,'-')).Append(value.PadRight(12,'-')).Append(cash).Append("\n");
                    }
                }
                else if (assetSummary[i].Account != null) {
                    for (int j = 0; j < assetSummary[i].Account.Count(); j++)
                    {
                        
                        if (assetSummary[i].Account[j].cash != null)
                            cash = assetSummary[i].Account[j].cash.amount;
                        assetSummaries.Append(assetSummary[i].ClassificationType.PadRight(19, '-')).Append(assetSummary[i].ClassificationValue.PadRight(20, '-')).Append(summaryContribution.PadRight(12, '-')).Append(summaryValue.PadRight(8, '-')).Append(" ".PadRight(8, '-')).Append(assetSummary[i].Account[j].id.PadRight(11, '-')).Append(value.PadRight(12, '-')).Append(cash).Append("\n");
                    }
                }
                else 
                assetSummaries.Append(assetSummary[i].ClassificationType.PadRight(19,'-')) .Append(assetSummary[i].ClassificationValue).Append("\n");
            }
            return assetSummaries.ToString();
        }
    }
}
