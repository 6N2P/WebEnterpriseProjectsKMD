﻿namespace WebEnterpriseProjectsKMD.Interfaces
{
    public interface IOrdersWorker
    {
        public void CreateOrdery(Order order);
        public void EditOrder(int id, string n);
        public void DeleteOrder(int id);
    }
}
