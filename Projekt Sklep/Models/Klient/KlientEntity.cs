﻿using Microsoft.AspNetCore.Identity;

namespace Projekt_Sklep.Models.Klient
{
    public class KlientEntity
    {
        public KlientEntity() : base() 
        { }
        public KlientEntity(Guid Id, string Name, string Pesel, string NumerTelefonu, string Email, string NIP, string LastName,string Login, string Password, Guid AdresID)
        {
            this.Id = Id;
            this.Name = Name;
            this.LastName = LastName;
            this.Pesel = Pesel;
            this.NumerTelefonu = NumerTelefonu;
            this.Email = Email;
            this.NIP = NIP;
            this.Login = Login;
            this.Password = Password;
            this.Adres = AdresID;
        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Pesel { get; set; }
        public virtual string NumerTelefonu { get; set; }
        public virtual string Email { get; set; }
        public virtual string NIP { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual Guid Adres  { get; set; }
     
    }
}
