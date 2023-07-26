using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing.Printing;

namespace Interface2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           /* using (MyDbContext db = new MyDbContext())
            {
                NetEquipments equipments1 = new() { ID = "N150", Name = "NETGEAR", Radius = 30, TypeOfConnection = "IEEE 802.11b" };
                NetEquipments equipments2 = new NetEquipments() { ID = "N300", Name = "NETGEAR", Radius = 12, TypeOfConnection = "IEEE 802.11g" };
                NetEquipments equipments3 = new NetEquipments() { ID = "N250", Name = "NETGEAR", Radius = 12, TypeOfConnection = "IEEE 802.11n" };
                NetEquipments equipments4 = new NetEquipments() { ID = "RT-N12 M", Name = "ASUS", Radius = 30, TypeOfConnection = "IEEE 802.11b" };
                NetEquipments equipments5 = new NetEquipments() { ID = "RT-N12 N", Name = "ASUS", Radius = 12, TypeOfConnection = "IEEE 802.11g" };
                NetEquipments equipments6 = new NetEquipments() { ID = "RT-N12 V", Name = "ASUS", Radius = 12, TypeOfConnection = "IEEE 802.11n" };
                NetEquipments equipments7 = new NetEquipments() { ID = "Archer C20", Name = "TP-Link", Radius = 12, TypeOfConnection = "IEEE 802.11ac" };
                NetEquipments equipments8 = new NetEquipments() { ID = "Archer C50", Name = "TP-Link", Radius = 12, TypeOfConnection = "IEEE 802.11ac" };
                NetEquipments equipments9 = new NetEquipments() { ID = "Archer C54", Name = "TP-Link", Radius = 12, TypeOfConnection = "IEEE 802.11ac" };
                NetEquipments equipments10 = new NetEquipments() { ID = "Archer C60", Name = "TP-Link", Radius = 12, TypeOfConnection = "IEEE 802.11ac" };
                NetEquipments equipments11 = new NetEquipments() { ID = "Router 4A", Name = "Xiaomi Mi", Radius = 12, TypeOfConnection = "IEEE 802.11ac" };
                NetEquipments equipments12 = new NetEquipments() { ID = "Router 4C", Name = "Xiaomi Mi", Radius = 12, TypeOfConnection = "IEEE 802.11n" };
                NetEquipments equipments13 = new NetEquipments() { ID = "Router AC2100", Name = "Xiaomi Redmi", Radius = 12, TypeOfConnection = "IEEE 802.11ac" };
                NetEquipments equipments14 = new NetEquipments() { ID = "DIR-1260", Name = "D-Link", Radius = 12, TypeOfConnection = "IEEE 802.11ac" };
                NetEquipments equipments15 = new NetEquipments() { ID = "DIR-825/R4", Name = "D-Link", Radius = 12, TypeOfConnection = "IEEE 802.11ac" };
                NetEquipments equipments16 = new NetEquipments() { ID = "DIR-615/Z1A", Name = "D-Link", Radius = 12, TypeOfConnection = "IEEE 802.11n" };
                NetEquipments equipments17 = new NetEquipments() { ID = "DIR-615", Name = "D-Link", Radius = 12, TypeOfConnection = "IEEE 802.11n" };
                NetEquipments equipments18 = new NetEquipments() { ID = "DIR-614", Name = "D-Link", Radius = 10, TypeOfConnection = "IEEE 802.11n" };
                db.NetEquipments.Add(equipments1);
                db.NetEquipments.Add(equipments2);
                db.NetEquipments.Add(equipments3);
                db.NetEquipments.Add(equipments4);
                db.NetEquipments.Add(equipments5);
                db.NetEquipments.Add(equipments6);
                db.NetEquipments.Add(equipments7);
                db.NetEquipments.Add(equipments8);
                db.NetEquipments.Add(equipments9);
                db.NetEquipments.Add(equipments10);
                db.NetEquipments.Add(equipments11);
                db.NetEquipments.Add(equipments12);
                db.NetEquipments.Add(equipments13);
                db.NetEquipments.Add(equipments14);
                db.NetEquipments.Add(equipments15);
                db.NetEquipments.Add(equipments16);
                db.NetEquipments.Add(equipments17);
                db.NetEquipments.Add(equipments18);
                db.SaveChanges();
            }*/

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Launch());
        }

    }
}