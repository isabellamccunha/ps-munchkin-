using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Munchkin.Domain.Shared.Abstractions;

namespace Munchkin.Domain.Entities
{
    internal class Turn
    {
        private Phase phase;

        public Turn() { }

        public void InitializeTurn() { }
        public void EndTurn() { }
    }
}
