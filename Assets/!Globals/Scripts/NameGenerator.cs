using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NameGenerator
{
    public class NameGenerator : MonoBehaviour
    {
        #region Functions

        // A function used to call the NameMaker we can make the function play 
        public void GenerateName()
        {
            // Logging To UnityConsole
            Debug.Log(NameMaker());
        }
            
        public string NameMaker()
        {
            #region FirstName
            string firstNames = "Jacob Ethan Michael Jayden William Alexander Noah Daniel Aiden Anthony Joshua Mason Christopher Andrew " +
                "David Matthew Logan Elijah James Joseph Gabriel Benjamin Ryan Samuel Jackson John Nathan Jonathan Christian Liam Dylan Landon " +
                "Caleb Tyler Lucas Evan Gavin Nicholas Isaac Brayden Luke Angel Brandon Jack Isaiah Jordan Owen Carter Connor Justin Jose Jeremiah " +
                "Julian Robert Aaron Adrian Wyatt Kevin Hunter Cameron Zachary Thomas Charles Austin Eli Chase Henry Sebastian Jason Levi Xavier " +
                "Ian Colton Dominic Juan Cooper Josiah Luis Ayden Carson Adam Nathaniel Brody Tristan Diego Parker Blake Oliver Cole Carlos Jaden " +
                "Jesus Alex Aidan Eric Hayden Bryan Max Jaxon Brian Bentley Alejandro Sean Nolan Riley Kaden Kyle Micah Vincent Antonio Colin " +
                "Bryce Miguel Giovanni Timothy Jake Kaleb Steven Caden Bryson Damian Grayson Kayden Jesse Brady Ashton Richard Victor Patrick " +
                "Marcus Preston Joel Santiago Maxwell Ryder Edward Miles Hudson Asher Devin Elias Jeremy Ivan Jonah Easton Jace Oscar Collin " +
                "Peyton Leonardo Cayden Gage Eduardo Emmanuel Grant Alan Conner Cody Wesley Kenneth Mark Nicolas Malachi George Seth Kaiden " +
                "Trevor Jorge Derek Jude Braxton Jaxson Sawyer Jaiden Omar Tanner Travis Paul Camden Maddox Andres Cristian Rylan Josue Roman " +
                "Bradley Axel Fernando Garrett Javier Damien Peter Leo Abraham Ricardo Francisco Lincoln Erick Drake Shane Cesar Stephen Jaylen " +
                "Tucker Kai Landen Braden Mario Edwin Avery Manuel Trenton Ezekiel Kingston Calvin Edgar Johnathan Donovan Alexis Israel Mateo " +
                "Silas Jeffrey Weston Raymond Hector Spencer Andre Brendan Zion Griffin Lukas Maximus Harrison Andy Braylon Tyson Shawn Sergio " +
                "Zane Emiliano Jared Ezra Charlie Keegan Chance Drew Troy Greyson Corbin Simon Clayton Myles Xander Dante Erik Rafael Martin " +
                "Dominick Dalton Cash Skyler Theodore Marco Caiden Johnny Ty Gregory Kyler Roberto Brennan Luca Emmett Kameron Declan Quinn " +
                "Jameson Amir Bennett Colby Pedro Emanuel Malik Graham Dean Jasper Everett Aden Dawson Angelo Reid Abel Dakota Zander Paxton ";
                #endregion
            #region LastName
            string lastName = "Smith Johnson Williams Jones Brown Davis Miller Wilson Moore Taylor Anderson Thomas Jackson " +
                "White Harris Martin Thompson Garcia Martinez Robinson Clark Rodriguez Lewis Lee Walker Hall Allen Young Hernandez King " +
                "Wright Lopez Hill Scott Green Adams Baker Gonzalez Nelson Carter Mitchell Perez Roberts Turner Phillips Campbell Parker " +
                "Evans Edwards Collins Stewart Sanchez Morris Rogers Reed Cook Morgan Bell Murphy Bailey Rivera Cooper Richardson Cox Howard " +
                "Ward Torres Peterson Gray Ramirez James Watson Brooks Kelly Sanders Price Bennett Wood Barnes Ross Henderson Coleman " +
                "Jenkins Perry Powell Long Patterson Hughes Flores Washington Butler Simmons Foster Gonzales Bryant Alexander Russell " +
                "Griffin Diaz Hayes Myers Ford Hamilton Graham Sullivan Wallace Woods Cole West Jordan Owens Reynolds Fisher Ellis " +
                "Harrison Gibson Mcdonald Cruz Marshall Ortiz Gomez Murray Freeman Wells Webb Simpson Stevens Tucker Porter Hunter Hicks " +
                "Crawford Henry Boyd Mason Morales Kennedy Warren Dixon Ramos Reyes Burns Gordon Shaw Holmes Rice Robertson Hunt Black " +
                "Daniels Palmer Mills Nichols Grant Knight Ferguson Rose Stone Hawkins Dunn Perkins Hudson Spencer Gardner Stephens Payne " +
                "Pierce Berry Matthews Arnold Wagner Willis Ray Watkins Olson Carroll Duncan Snyder Hart Cunningham Bradley Lane Andrews " +
                "Ruiz Harper Fox Riley Armstrong Carpenter Weaver Greene Lawrence Elliott Chavez Sims Austin Peters Kelley Franklin Lawson " +
                "Fields Gutierrez Ryan Schmidt Carr Vasquez Castillo Wheeler Chapman Oliver Montgomery Richards Williamson Johnston " +
                "Banks Meyer Bishop Mccoy Howell Alvarez Morrison Hansen Fernandez Garza Harvey Little Burton Stanley Nguyen George " +
                "Jacobs Reid Kim Fuller Lynch Dean Gilbert Garrett Romero Welch Larson Frazier Burke Hanson Day Mendoza Moreno Bowman " +
                "Medina Fowler Brewer Hoffman Carlson Silva Pearson Holland Douglas Fleming Jensen Vargas Byrd Davidson Hopkins May " +
                "Terry Herrera Wade Soto Walters Curtis Neal Caldwell Lowe Jennings Barnett Graves Jimenez Horton Shelton Barrett Castro " +
                "Sutton Gregory Mckinney Lucas Miles Craig Rodriquez Chambers Holt Lambert Fletcher Watts Bates Hale Rhodes Pena Beck " +
                "Newman Haynes Mcdaniel Mendez Bush Vaughn Parks Dawson Santiago Norris Hardy Love Steele Curry Powers Schultz Barker " +
                "Guzman Page Munoz Ball Keller Chandler Weber Leonard Walsh Lyons Ramsey Wolfe Schneider Mullins Benson Sharp Bowen Daniel ";
            #endregion

            string[] male_firstNames = firstNames.Split(' ');
            string[] male_lastNames = lastName.Split(' ');
            // Returns a random index for both firstnames array and last names array and adds them together to from first name and last name
            return male_firstNames[Random.Range(0,male_firstNames.Length - 1)] + " " + male_lastNames[Random.Range(0, male_lastNames.Length - 1)];
        }

        #endregion
    }
}
