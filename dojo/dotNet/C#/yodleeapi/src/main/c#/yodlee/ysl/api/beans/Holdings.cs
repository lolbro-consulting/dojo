using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.beans
{

    public class Holdings
    {
        public IList<Holding> holding { get; set;}//getting deserialized value for holding class.


        public override string ToString()
        {
            StringBuilder holdings = new StringBuilder("");
            if (holding == null)
                return holdings.ToString();
            for (int i = 0; i < holding.Count; i++)
            {
                string description = "NA";
                if (holding[i].description != null)
                    description = holding[i].description;
                string value="NA";
                if(holding[i].Value!=null)
                    value =holding[i].Value.amount;
                if (holding[i].AssetClassification!=null) {
                    AssetClassification[] ac = holding[i].AssetClassification;
                    
                    for (int j = 0; j < ac.Count(); j++)
                    {
                        String allocation = "NA";
                        if(holding[i].AssetClassification[j].Allocation!=null)
                         allocation = holding[i].AssetClassification[j].Allocation;
                        holdings.Append(holding[i].Id.PadRight(10, '-')).Append(holding[i].AccountId.PadRight(15, '-')).Append(description.PadRight(10, '-')).Append(holding[i].holdingType.PadRight(15, '-')).Append(value.PadRight(15, '-')).Append(holding[i].AssetClassification[j].ClassificationType.PadRight(15,'-')).Append(holding[i].AssetClassification[j].ClassificationValue.PadRight(25,'-')).Append(allocation).Append("\n");
                    }
                }
                else
                    holdings.Append(holding[i].Id.PadRight(10, '-')).Append(holding[i].AccountId.PadRight(15, '-')).Append(description.PadRight(10, '-')).Append(holding[i].holdingType.PadRight(15, '-')).Append(value.PadRight(15, '-')).Append("\n");
          
            }
            return holdings.ToString();
        }

    }
}