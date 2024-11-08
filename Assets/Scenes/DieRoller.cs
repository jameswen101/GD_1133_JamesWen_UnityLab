using System;

public class DieRoller
{
    public int numberOfSides;
    public int roll; //value of number rolled
    Random random = new Random(); //Create an instance of Random

    public int Roll()
    {
        roll = random.Next(1, numberOfSides + 1); //generates a random number within the die range
        return roll;
    }
    public DieRoller(int numberOfSides) //constructor, number of sides a parameter for each object
    {
        this.numberOfSides = numberOfSides;
    }
}
