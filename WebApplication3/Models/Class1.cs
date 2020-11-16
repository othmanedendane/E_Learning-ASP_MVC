using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Class1
    {
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Required]
        public string nom { get; set; }
        [Required]
        
        public string prenom { get; set; }

        [Required]

        public string age { get; set; }

    

        public string login { get; set; }

     

        public string pw { get; set; }
    }


    public class Enterwhatever
    {
        public void InsertData(Class1 li)
    {

        DataClasses1DataContext db = new DataClasses1DataContext();
        perso rs = new perso();

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringCharsuser = new char[6];
            var stringCharspass = new char[8];
            var random = new Random();

            for (int i = 0; i < stringCharsuser.Length; i++)
            {
                stringCharsuser[i] = chars[random.Next(chars.Length)];
            }
            for (int i = 0; i < stringCharspass.Length; i++)
            {
                stringCharspass[i] = chars[random.Next(chars.Length)];
            }


            li.login = new String(stringCharsuser);
            li.pw = new String(stringCharspass);


            rs.Id = li.Id;
        rs.nom = li.nom;
        rs.prenom = li.prenom;
        rs.age = li.age;
        rs.login = li.login;
        rs.pw = li.pw;


            db.perso.InsertOnSubmit(rs);
        db.SubmitChanges();

    }

    }



    public class Search
    {

        public string searchLP(Class1 li)
        {

            DataClasses1DataContext db = new DataClasses1DataContext();
            perso rs = new perso();
            string passout = "";
            // var pass = from m in db.registers where m.emailid == li.Emailid select m.userpassword;  
            var pass = from m in db.perso where m.login == li.login select m.pw;
            // var pass = from m in db.registers where m.emailid == li.Emailid select m.userpassword;
            foreach (string query in pass)
            {
                passout = query;

            }
            return passout;

        }

    }

}