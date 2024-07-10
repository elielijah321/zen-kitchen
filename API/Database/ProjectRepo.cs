using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project.Function;

namespace AzureFunctions.Database
{
    public class ProjectRepo
    {
        private readonly ProjectContext _ctx;

        public ProjectRepo(ProjectContext ctx)
        {
            _ctx = ctx;
        }

        public void AddDefendant(Defendant newDefendant)
        {
           _ctx.Defendants.Add(newDefendant);
           SaveAll();
        }

        public void UpdateDefendant(Defendant newDefendant)
        {
           var defendantToUpdate = _ctx.Defendants.FirstOrDefault(c => c.Id == newDefendant.Id);
           defendantToUpdate.Name = newDefendant.Name;
           defendantToUpdate.Email = newDefendant.Email;
           defendantToUpdate.Address_Line1 = newDefendant.Address_Line1;
           defendantToUpdate.Address_City = newDefendant.Address_City;
           defendantToUpdate.Address_PostalCode = newDefendant.Address_PostalCode;

           SaveAll();
        }

        public IEnumerable<Defendant> GetAllDefendants()
        {
           return _ctx.Defendants;
        }

        public Defendant GetDefendantById(string id)
        {
           return GetAllDefendants().FirstOrDefault(x => x.Id.ToString() == id);
        }

        public Defendant GetDefendantByEmail(string email)
        {
           return GetAllDefendants().FirstOrDefault(x => x.Email == email);
        }

      public void AddCase(Case newCase)
      {
         _ctx.Cases.Add(newCase);
         SaveAll();
      }

        public void UpdateCase(Case newCase)
        {
           var caseToUpdate = _ctx.Cases.FirstOrDefault(c => c.Id == newCase.Id);
           caseToUpdate.Title = newCase.Title;

           SaveAll();
        }

        public IEnumerable<Case> GetAllCases()
        {
           return _ctx.Cases;
        }

        public Case GetCaseById(string id)
        {
           return GetAllCases().FirstOrDefault(x => x.Id.ToString() == id);
        }

        public Case GetCaseByTitle(string title)
        {
           return GetAllCases().FirstOrDefault(x => x.Title == title);
        }

        public IEnumerable<Case> GetCaseByTerm(string searchTerm)
        {
           return GetAllCases().Where(c => 
                            c.Title.ToLower().Contains(searchTerm)
                        );
        }

        // Save
        private bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}