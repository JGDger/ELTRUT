using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest
{
    class Creature: IComparable<Creature>
    {
        public int X;
        public int Y;
        public int ID;
        public int Position;
        public bool Stopped = false;
        public List<Command> program;
        public static int[,] field;
        public static Random RNG = new Random((int)DateTime.Now.Ticks);

        private int forStartPos;
        private bool forStarted;
        private int forDelta;
        private int forEndPos;
        public Creature(int id)
        {
            ID = id;
            program = new List<Command>();
            int num = RNG.Next(4, 10);
            for (int i = 0; i < num; i++)
            {
                int op = RNG.Next(0, 5);
                if (op == 4)
                {
                    int forM = RNG.Next(2, 5);
                    int forC = RNG.Next(1, 3);
                    Command C = new Command(Commands.FOR_C);
                    C.forM = forM;
                    C.forOps = forC;
                    program.Add(C);
                    for (int j = 0; j < forC; j++)
                    {
                        op = RNG.Next(0, 4);
                        program.Add(new Command(op));
                    }
                    continue;
                }
                program.Add(new Command(op));
            }
            X = 0;
            Y = 0;
            Position = 0;
        }
        public Creature Clone()
        {
            Creature x = new Creature(ID);
            x.program = this.program;
            x.ID = this.ID;
            for (int i = 0; i < x.program.Count; i++) x.Step();
            return x;
        }
        public void Step()
        {
            if (Position >= program.Count() || X==field.GetUpperBound(0) && Y==field.GetUpperBound(1)) { Stopped = true; return; }
            switch (program[Position].op)
            {
                case Commands.X_INC:
                    if (X < field.GetUpperBound(0))
                        if (field[X + 1, Y] == 0)
                            X++;
                    break;
                case Commands.X_DEC:
                    if (X > 0)
                        if (field[X - 1, Y] == 0)
                            X--;
                    break;
                case Commands.Y_INC:
                    if (Y < field.GetUpperBound(1))
                        if (field[X, Y + 1] == 0)
                            Y++;
                    break;
                case Commands.Y_DEC:
                    if (Y > 0)
                        if (field[X, Y - 1] == 0)
                            Y--;
                    break;
                case Commands.FOR_C:
                    forStarted = true;
                    forDelta = program[Position].forM;
                    forStartPos = Position;
                    forEndPos = Position + program[Position].forOps;
                    //Console.WriteLine("FOR from " + forStartPos + " to " + forEndPos + " " + forDelta + " times");
                    break;
            }
            if (forStarted && Position == forEndPos)
            {
                forDelta--;
                if (forDelta == 0) forStarted = false;
                else Position = forStartPos;
            }
            Position++;
        }
        public void Restart()
        {
            X = 0;
            Y = 0;
            Position = 0;
            Stopped = false;
        }
        public void Mutate()
        {
            int numberOfMutations =  RNG.Next(1, 4);
            for (int i = 0; i < numberOfMutations; i++)
            {
                int mutateType = RNG.Next(0, 100);
                if (mutateType < 60)
                {
                    int pos = RNG.Next(program.Count);
                    int newOp = RNG.Next(5);
                    if (newOp == 4)
                    {
                        int forM = RNG.Next(2, 5);
                        int forC = RNG.Next(1, 3);
                        Command C = new Command(Commands.FOR_C);
                        C.forM = forM;
                        C.forOps = forC;
                        program[pos]=(C);
                        for (int j = 0; j < forC; j++)
                        {
                            newOp = RNG.Next(0, 4);
                            program.Insert(pos,new Command(newOp));
                        }
                        continue;
                    }
                    program[pos] = new Command(newOp);
                }
                else if (mutateType < 75)
                {
                    int pos = RNG.Next(program.Count);
                    int newOp = RNG.Next(4);
                    program.Insert(pos, new Command(newOp));
                }
                else
                {
                    int pos = RNG.Next(program.Count);
                    if (program.Count > 2) program.RemoveAt(pos);
                }
            }
        }
        public int Distance()
        {
            //return Math.Round(Math.Sqrt(Math.Pow(field.GetUpperBound(0) - X - 1, 2d) + Math.Pow(field.GetUpperBound(1) - 1 - Y, 2d)) * 100) / 100d;
            return (field.GetUpperBound(0) + field.GetUpperBound(1)-X - Y);
        }
        public int Rank()
        {
            return (int)(Math.Pow((Distance() + 1), 4) * (Position) / 3);
        }

        public int CompareTo(Creature obj)
        {
            Restart(); obj.Restart();
            while(!Stopped) Step();
            while (!obj.Stopped) obj.Step();
            return (int)(this.Rank() - obj.Rank());
        }
    }
    class Command {
        public Commands op;
        public int forC = 0;
        public int forM;
        public int forOps;
        public Command(Commands cmd)
        {
            op = cmd;
        }
        public Command(int cmd)
        {
            op = (Commands)cmd;
        }
        public new string ToString()
        {
            if (op != Commands.FOR_C)
                return op.ToString();
            else
                return "FOR_"+forOps+"x"+forM;
        }
    }
    enum Commands
    {
        X_INC=0,
        X_DEC=1,
        Y_INC=2,
        Y_DEC=3,
        FOR_C=4
    }
}
