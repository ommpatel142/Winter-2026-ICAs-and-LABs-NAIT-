/*
 * Name: Om Patel
 * Assignment: Lab 01: dinero Facil
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace lab01_OmP
{
    internal class Program
    {
        static int[] Cents = { 5000, 2000, 1000, 500, 200, 100, 25, 10, 5 };
        static string[] Labels = { "$50", "$20", "$10", "$5", "$2", "$1", "$0.25", "$0.10", "$0.05" };
        static readonly string[] NameLabels ={"Fifty","Twenty","Ten","Five","Toonie","Loonie","Quarter","Dime","Nickel"};
        static CDrawer drawer;

        // Main: Program entry point. Gets input, processes values,
        // prints the report, and renders the visual output.
        static void Main(string[] args)
        {
            drawer = new CDrawer(800, 600,false);
            drawer.Scale = 1;
            bool valid;
            int originalCents;
            int roundedCents;
            do
            {
                Console.WriteLine("How much money do you wish to convert");
                string value = Console.ReadLine();

                valid = GetCents(value, out originalCents, out roundedCents);
                if (!valid)
                {
                    Console.WriteLine("Invalid input.");
                }
            } while (!valid);
            int[] counts = Counts(roundedCents);
            PrintReport(originalCents, roundedCents, counts);
            RenderDrawer(roundedCents, counts);
            drawer.Render();

            Console.WriteLine("Press ENTER to exit...");
            Console.Read();
        }

        // GetCents: Validates user input, converts to cents,
        // and rounds the value to the nearest nickel.
        static bool GetCents(string input, out int originalCents, out int roundedCents)
        {
            originalCents = 0;
            roundedCents = 0;

            if (input == null)
                return false;

            input = input.Trim();
            input = input.Replace("$", "");

            if (!decimal.TryParse(input, out decimal amount))
                return false;

            if (amount < 0)
                return false;

            originalCents = (int)Math.Round(amount * 100m);

            roundedCents = ((originalCents + 2) / 5) * 5;

            return true;
        }

        // Counts: Determines how many of each denomination
        // are required for the given cent value.
        static int[] Counts(int totalCents)
        {
            int[] counts = new int[Cents.Length];
            int remaining = totalCents;

            for (int i = 0; i < Cents.Length; i++)
            {
                counts[i] = remaining / Cents[i];
                remaining = remaining % Cents[i];
            }
            return counts;
        }

        // PrintReport: Displays the rounded value and the count
        // of each bill and coin in the console.
        static void PrintReport(int originalCents, int roundedCents, int[] counts)
        {
            Console.WriteLine($"User entry of {(originalCents / 100m):C} interpreted and rounded to {(roundedCents / 100m):C}");
            for (int i = 0; i < counts.Length; i++)
            { 
                    Console.WriteLine($"{NameLabels[i]}x{counts[i]}");
            }
        }

        // RenderDrawer: Draws bills and coins in columns using
        // GDIDrawer based on the calculated counts.
        static void RenderDrawer(int roundedCents, int[] counts)
        {
            drawer.Clear();

            string totalText = (roundedCents / 100.0).ToString("C");
            drawer.AddText(totalText, 24, 0, 10, drawer.m_ciWidth, 40, Color.Yellow);

            int[] drawIdx = new int[counts.Length];
            int drawCount = 0;

            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > 0)
                {
                    drawIdx[drawCount] = i;
                    drawCount++;
                }
            }

            int itemsPerCol = 5;

            int startX = 220;    
            int startY = 90;      
            int colGap = 240;    
            int rowGap = 95;      

            int billW = 180;
            int billH = 60;
            int coinD = 70;

            Color[] billColors = {Color.Pink,Color.LightGreen,Color.Lavender,Color.LightBlue};

            for (int k = 0; k < drawCount; k++)
            {
                int idx = drawIdx[k];

                int col = k / itemsPerCol;
                int row = k % itemsPerCol;

                int x = startX + col * colGap;
                int y = startY + row * rowGap;

                if (idx >= 0 && idx <= 3)
                {
                    drawer.AddRectangle(x, y, billW, billH, billColors[idx]);

                    drawer.AddText($"{Labels[idx]} x {counts[idx]}", 14, x, y, billW, billH, Color.Black);
                }
                else
                {
                    Color fill = Color.LightGray;

                    if (idx == 4) fill = Color.Beige;   
                    if (idx == 5) fill = Color.Gold;    

                    drawer.AddEllipse(x + (billW - coinD) / 2, y, coinD, coinD, fill);

                    int coinX = x + (billW - coinD) / 2;
                    drawer.AddText($"{Labels[idx]} x {counts[idx]}", 11, coinX, y, coinD, coinD, Color.Black);
                }
            }

        }
    }
}
