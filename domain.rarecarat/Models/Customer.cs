namespace domain.rarecarat.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string AccountGrpCli { get; set; }
        public string NameTwo { get; set; }
        public string StreetOne { get; set; }
        public string StreetTwo { get; set; }
        public string PostalCode { get; set; }
        public string Location { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Region { get; set; }
        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Mail { get; set; }
        public string NIF { get; set; }
        public string ClientBlocking { get; set; }
        public string Provider { get; set; }
        public string Kdgrp { get; set; }
        public string HeadOffice { get; set; }
        public string ClientHeadOffice { get; set; }
        public string Directions { get; set; }
    }
}