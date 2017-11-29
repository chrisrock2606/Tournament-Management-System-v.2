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
                if (tournament.ID > Id)
                    Id = tournament.ID;

                foreach (var round in tournament.Rounds)
                {
                    if (round.ID > Id)
                        Id = round.ID;
                    
                    foreach (var match in round.Matches)
                    {
                        if (match.ID > Id)
                            Id = match.ID;
                    }
                }
            }
        }
    }
}
