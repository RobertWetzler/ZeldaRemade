using Project;
using Project.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Commands
{
    class EnemyTakeDamageCommand : ICommand
    {
        private INPC npc;
        public EnemyTakeDamageCommand(INPC npc, CollisionSide side)
        {
            this.npc = npc;
        }

        public void Execute()
        {
            Console.WriteLine("Enemy took damage!");
        }
    }
}
