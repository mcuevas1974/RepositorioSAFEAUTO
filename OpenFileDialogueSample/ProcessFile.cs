using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenFileDialogueSample
{
    class ProcessFile
    {
        public string ReadFileFromPath(string path)
        {
            String line;
            string Retorno = string.Empty;
            List<Object> myObjects = new List<Object>();
            List<Driver> myDrivers = new List<Driver>();
            List<Trip> myTrips = new List<Trip>();
            try
            {
                StreamReader sr = new StreamReader(path.ToString());
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                    //Llenamos un arraylist line por linea
                    if (line != null)
                    {
                        string[] words = line.Split(' ');
                        if (words[0].ToString() == "Driver")
                        {
                            Driver myDriver = new Driver();
                            myDriver.name = words[1].ToString();
                            myDrivers.Add(myDriver);
                        }
                        if (words[0].ToString() == "Trip")
                        {
                            Trip myTrip = new Trip();
                            myTrip.name = words[1] != "" ? words[1].ToString() : "";
                            myTrip.InitialTime = words[2] != "" ? Convert.ToDateTime(words[2]) : Convert.ToDateTime("12:00");
                            myTrip.FinalTime = words[3] != "" ? Convert.ToDateTime(words[3]) : Convert.ToDateTime("12:00");
                            myTrip.Distance = words[4] != "" ? Convert.ToDouble(words[4]) : Convert.ToDouble("0");
                            myTrips.Add(myTrip);
                        }

                    }
                }
                
                foreach (object myObject in myDrivers)
                {
                    Driver myDriverActual = new Driver();
                    myDriverActual = (Driver)myObject;
                    List<Trip> myTripsCalculte = new List<Trip>();
                    myTripsCalculte = myTrips.Where(Trip => Trip.name.Equals(myDriverActual.name )).ToList();
                    int Itera = 0;
                   foreach(Trip myTrip in myTripsCalculte)
                    {
                        Itera++;
                        //Calculate de Distance
                        myDriverActual.Distance  = myDriverActual.Distance  + myTrip.Distance;
                        myDriverActual.Distance = myDriverActual.Distance;
                        //Calculate de Velocity
                        myDriverActual.Velocity = myDriverActual.Velocity + myTrip.Distance * (60)/(myTrip.FinalTime - myTrip.InitialTime).TotalMinutes;
                    }
                    myDriverActual.Distance = (int)Math.Round(Convert.ToDouble(myDriverActual.Distance), 0, MidpointRounding.ToEven);
                    myDriverActual.Velocity = (int)Math.Round(Convert.ToDouble(myDriverActual.Velocity / Itera), 0, MidpointRounding.ToEven);
                    if(myDriverActual.Distance>0)
                        Retorno = Retorno + myDriverActual.name + ":" + myDriverActual.Distance.ToString() + " miles @ " + myDriverActual.Velocity.ToString() + " mph \r\n";
                }
                sr.Close();
               
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            return Retorno;
        }
    }
}
