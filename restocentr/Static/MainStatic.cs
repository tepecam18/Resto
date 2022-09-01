using restocentr.Model;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.SignalR.Client;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Windows.Threading;
using Microsoft.Win32;

namespace restocentr.Static
{
    internal static class St
    {
        public static List<ProductGroupModel> ProductGroup = new();
        public static List<OrderModel> Orders = new();
        public static OrderModel Order = new();
    }
}
