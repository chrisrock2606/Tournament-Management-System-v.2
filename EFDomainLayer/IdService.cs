using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDomainLayer;
using DomainLayer;

namespace DomainLayer
{
    public class IdService
    {
        private int Id;

        private static IdService instance;
        public static IdService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new IdService();
                }
                return instance;
            }
        }

        private IdService()
        { SetId(); }

        public int GetNewId()
        {
            Id += 1;
            return Id;
        }

        private void SetId()
        {
            foreach (var tournament in TournamentRepository.Instance.GetTournaments())
            {
                if (tournament.Id > Id)
                    Id = tournament.Id;

                foreach (var round in tournament.Rounds)
                {
                    if (round.Id > Id)
                        Id = round.Id;
                    
                    foreach (var match in round.Matches)
                    {
                        if (match.Id > Id)
                            Id = match.Id;
                    }
                }
            }
        }
    }
}
