using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21._12._22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            House house = new House();
            Team team = new Team(2);
            team.workers[0].DoWork(house);
            team.workers[1].DoWork(house);
            team.workers[0].DoWork(house);
            team.workers[1].DoWork(house);
            team.workers[0].DoWork(house);
            team.workers[1].DoWork(house);
            team.workers[0].DoWork(house);
            team.workers[1].DoWork(house);
            team.workers[0].DoWork(house);
            team.workers[1].DoWork(house);
            team.workers[0].DoWork(house);
            team.teamLeader.DoWork(house);
        }
    }

    interface IWorker
    {
        void DoWork(House house);
    }

    interface IPart
    {
        void GetPartInfo();
        void Build(House house);
    }

    class House
    {
        Basement basement = null;
        Walls[] walls = new Walls[4];
        int wallCounter = 0;
        Door door = null;
        Window[] window = new Window[4];
        int windowCounter = 0;
        Roof roof = null;
        public void Show()
        {
            Console.Clear();
            if (basement!=null)
                basement.GetPartInfo();
            foreach (var e in walls)
                if (e != null)
                    e.GetPartInfo();
            if (door != null)
                door.GetPartInfo();
            foreach (var e in window)
                if (e != null)
                    e.GetPartInfo();
            if (roof != null)
            {
                Done();
            }
        }
        public IPart CheckPart()
        {
            if (basement == null)
                return new Basement();
            foreach (var e in walls)
                if (e == null)
                    return new Walls();
            if (door == null)
                return new Door();
            foreach (var e in window)
                if (e == null)
                    return new Window();
            if (roof == null)
                return new Roof();
            return null;
        }
        public void Add(IPart part)
        {
            if (part == null)
            {
                Done();
                return;
            }
            else if (part.GetType() == new Basement().GetType())
            {
                basement = (Basement)part;
            }
            else if (wallCounter < 4)
            {
                if (part.GetType() == new Walls().GetType())
                {
                    walls[wallCounter] = (Walls)part;
                    wallCounter++;
                }
            }
            else if (part.GetType() == new Door().GetType())
            {
                door = (Door)part;
            }
            else if (windowCounter < 4)
            {
                if (part.GetType() == new Window().GetType())
                {
                    window[windowCounter] = (Window)part;
                    windowCounter++;
                }
            }
            else if (part.GetType() == new Roof().GetType())
            {
                roof = (Roof)part;
            }
        }
        void Done()
        {
            Console.Clear();
            Console.WriteLine("ДОМ ПОСТРОЕН!");
            Console.WriteLine(@"      ___
    /\| |
   /  \ |
  /    \|
 /      \
/________\
|  ___   |
|  | | []|
|  | |   |
----------
");
        }
    }

    class Basement : IPart
    {
        public void GetPartInfo()
        {
            Console.WriteLine("подвал");
        }
        public void Build(House house)
        {
            house.Add(new Basement());
        }
    }

    class Walls : IPart
    {
        public void GetPartInfo()
        {
            Console.WriteLine("стена");
        }
        public void Build(House house)
        {
            house.Add(new Walls());
        }
    }

    class Door : IPart
    {
        public void GetPartInfo()
        {
            Console.WriteLine("дверь");
        }
        public void Build(House house)
        {
            house.Add(new Door());
        }
    }

    class Window : IPart
    {
        public void GetPartInfo()
        {
            Console.WriteLine("окно");
        }
        public void Build(House house)
        {
            house.Add(new Window());
        }
    }

    class Roof : IPart
    {
        public void GetPartInfo()
        {
            Console.WriteLine("крыша");
        }
        public void Build(House house)
        {
            house.Add(new Roof());
        }
    }

    class Team
    {
        public TeamLeader teamLeader;
        public Worker[] workers;

        public Team (int workerCounter)
        {
            teamLeader = new TeamLeader();
            workers = new Worker[workerCounter];
            for (int i = 0; i < workerCounter; i++)
            {
                workers[i] = new Worker();
            }
        }
    }

    class Worker : IWorker
    {
        public void DoWork(House house)
        {
            IPart part = house.CheckPart();
            house.Add(part);
        }
    }

    class TeamLeader : IWorker
    {
        public void DoWork(House house)
        {
            house.Show();
        }
    }
}
