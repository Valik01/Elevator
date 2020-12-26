using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace ElevatorSystem
{
    class Person
    {
        private int[] numberFloor;
        private int number;
        private int positionX;
        private int positionY;
        private int positionX_old;
        private int positionY_old;
        private int lengthFloor;

        private string status;
        private int weight;

        private bool wait;
        private bool enable;
        private bool exitFloor;
        private bool moveInLift;
        private int speedX;

        public Person(int number, int positionX, int positionY, int[] numberFloor) {
            this.number = number;
            this.positionX = positionX + 90;
            this.positionY = positionY + 20;
            lengthFloor = positionX + 370;

            this.numberFloor = numberFloor;
            status = "Движется на этаже " + (numberFloor[0] + 1);

            Random rnd = new Random((int)(DateTime.Now.Ticks));
            speedX = 1;
            weight = rnd.Next(50, 150);
            enable = true;
            exitFloor = false;
            moveInLift = false;
            wait = false;
        }
        public Person(int number, int positionX, int positionY, int[] numberFloor, int weight)
        {
            this.number = number;
            this.positionX = positionX + 90;
            this.positionY = positionY + 20;
            this.weight = weight;
            lengthFloor = positionX + 370;

            this.numberFloor = numberFloor;
            status = "Движется на этаже " + (numberFloor[0] + 1);
          
            speedX = 1;
            enable = true;
            exitFloor = false;
            moveInLift = false;
            wait = false;
        }

        public void personClick() {
            PersonInformation personInformation = new PersonInformation(status);
            personInformation.ShowDialog();
        }

        public bool NextMove() {

            Lift lift = Lift.getInstance(0, 0, 0, new int[] { 0, 0 });

            if (positionX < lengthFloor && !moveInLift && !exitFloor) //движется от двери к лифту
            {
                positionX_old = positionX;
                positionY_old = positionY;
                positionX += speedX;
            }
            else if (!wait && !moveInLift && !exitFloor) //ожидает лифта на своем этаже
            {
                wait = true;
                status = "Ждёт на этаже " + (numberFloor[0] + 1);
                lift.callTheElevator(numberFloor[0], numberFloor[1]);
            }
            else if (numberFloor[0] == lift.CurrentFloor && !moveInLift && !exitFloor && lift.Weight + weight < 400) //едет в лифте
            {
                enable = false;
                moveInLift = true;
                lift.Weight = weight;
                lift.sumWeight = weight;
                lift.MoveUp = false;
                status = "Движется на нужный этаж";
                lift.moveTheElevator(numberFloor[0]);
            }
            else if (numberFloor[1] == lift.CurrentFloor && moveInLift && !exitFloor) //выходит из лифта 
            {
                enable = true;
                exitFloor = true;
                positionY = lift.PositionY + 15;
                lift.Weight = -weight;
                lift.MoveUp = false;
                status = "Выходит на этаже " + (numberFloor[1] + 1);
                lift.exitTheElevator(numberFloor[1]);
            } else if (exitFloor) //движется к двери после выхода из лифта
            {
                positionX_old = positionX;
                positionY_old = positionY;
                positionX -= speedX;
            }
            return enable;               
        }

       

        public int PositionX
        {
            get
            {
                return positionX;
            }
        }

        public int PositionY
        {
            get
            {
                return positionY;
            }
        }

        public int OldX
        {
            get
            {
                return positionX_old;
            }
        }

        public int OldY
        {
            get
            {
                return positionY_old;
            }
        }
    }
}
