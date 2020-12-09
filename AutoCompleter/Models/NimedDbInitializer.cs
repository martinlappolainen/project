using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AutoCompleter.Models
{
    public class NimedDbInitializer : CreateDatabaseIfNotExists<NimedContext>
    {
        protected override void Seed(NimedContext db)
        {
            db.Nimeds.Add(
                new Nimed
                {
                    Id = 1,
                    Sugu = "Mees",
                    Emakeelnenimi = "Мартин",
                    Voorkeelnenimi = "Martin"
                });
            db.Nimeds.Add(
                new Nimed
                {
                    Id = 2,
                    Sugu = "Mees",
                    Emakeelnenimi = "Александр",
                    Voorkeelnenimi = "Aleksandr"
                });

            base.Seed(db);
        }
    }
}