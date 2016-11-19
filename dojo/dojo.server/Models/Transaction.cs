using System;

namespace dojo.server.Models
{
    public class Transaction
    {
        public string Container { get; set; }

        public int Id { get; set; }

        public Amount Amout { get; set; }

        public string BaseType { get; set; }

        public string CategoryType { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public Description Description { get; set; }

        public bool IsManual { get; set; }

        public DateTime Date { get; set; }

        public DateTime PostDate { get; set; }

        public string Status { get; set; }

        public int AcountId { get; set; }

        public Merchant Merchant { get; set; }

        public int HighLevelCategoryId { get; set; }
    }

    public sealed class Amount
    {
        public double Amout { get; set; }

        public string Currency { get; set; }
    }

    public sealed class Description
    {
        public string Original { get; set; }

        public string Simple { get; set; }
    }

    public sealed class Merchant
    {
        public string Name { get; set; }
    }
}