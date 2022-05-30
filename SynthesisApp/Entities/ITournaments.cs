﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface ITournaments<T>
    {
        public void AddTournament(T tournament);
        public List<Tournament> ReadTournaments();
        public void UpdateTournament(T tournament);
        public void DeleteTournament(T tournament);
    }
}