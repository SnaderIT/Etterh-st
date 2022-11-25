﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;



//jeg tok litt styling og arrangemt på hvotdan menyen skulle se ut fra andre 


namespace MenuBuilder
{
    class Menu
    {
        //private string _prompt = "";
        private readonly string[] _options;
        private int _currentSelection;
        private int _drawMenuColumnPos;
        private readonly int _drawMenuRowPos;
        private int _menuMaximumWidth;

        public Menu(string[] options, int row, int col)
        {
            //_prompt = prompt;
            _options = options;
            _currentSelection = 1;
            _drawMenuRowPos = row;
            _drawMenuColumnPos = col;

        }

        public int GetMaximumWidth()
        {
            return _menuMaximumWidth;
        }

        public void CenterMenuToConsole()
        {
            _drawMenuColumnPos = GetConsoleWindowWidth() / 2 - (_menuMaximumWidth / 2);
        }

        // Modify the menu to be left justified
        public void ModifyMenuLeftJustified()
        {
            int maximumWidth = 0;
            string space = "";

            foreach (var t in _options)
            {
                if (t.Length > maximumWidth)
                {
                    maximumWidth = t.Length;
                }
            }

            maximumWidth += 6;

            for (int i = 0; i < _options.Length; i++)
            {
                int spacesToAdd = maximumWidth - _options[i].Length;
                for (int j = 0; j < spacesToAdd; j++)
                {
                    space += " ";
                }
                _options[i] = _options[i] + space;
                space = "";
            }

            _menuMaximumWidth = maximumWidth;
        }

        // Modify the menu to be centered in its column
        public void ModifyMenuCentered()
        {
            int maximumWidth = 0;
            string space = "";

            foreach (var t in _options)
            {
                if (t.Length > maximumWidth)
                {
                    maximumWidth = t.Length;
                }
            }

            maximumWidth += 6;     // make widest measurement wider by 10
                                   // modify this number to make menu wider / narrower

            for (int i = 0; i < _options.Length; i++)
            {
                if (_options[i].Length % 2 != 0)
                {
                    _options[i] += " ";     // make all menu items even num char wide
                }

                var minimumWidth = maximumWidth - _options[i].Length;
                minimumWidth /= 2;
                for (int j = 0; j < minimumWidth; j++)
                {
                    space += " ";
                }

                _options[i] = space + _options[i] + space;      // add spaces on either side of each    
                space = "";                             // menu item
            }

            for (int i = 0; i < _options.Length; i++)
            {
                if (_options[i].Length < maximumWidth)      // if any menu item isn't as wide as
                                                            // the max width, add 1 space
                {
                    _options[i] += " ";
                }
            }

            _menuMaximumWidth = maximumWidth;           // set the max width for use later

        }

        // UTILITIES FOR THE CLASS
        public void SetConsoleWindowSize(int width, int height)
        {
            WindowWidth = width;
            WindowHeight = height;
        }

        public static int GetConsoleWindowWidth()
        {
            return WindowWidth;
        }

        public void SetConsoleTextColor(ConsoleColor foreground, ConsoleColor background)
        {
            ForegroundColor = foreground;
            BackgroundColor = background;
        }

        public void ResetCursorVisible()
        {
            CursorVisible = CursorVisible != true;
        }

        public void SetCursorPosition(int row, int column)
        {
            if (row > 0 && row < WindowHeight)
            {
                CursorTop = row;
            }

            if (column > 0 && column < WindowWidth)
            {
                CursorLeft = column;
            }
        }


        // Engine to run the menu and relevant methods
        public int RunMenu()
        {
            bool run = true;
            DrawMenu();
            while (run)
            {
                var keyPressedCode = CheckKeyPress();
                if (keyPressedCode == 10)   // up arrow
                {
                    _currentSelection--;
                    if (_currentSelection < 1)
                    {
                        _currentSelection = _options.Length;
                    }

                }
                else if (keyPressedCode == 11)  // down arrow
                {
                    _currentSelection++;
                    if (_currentSelection > _options.Length)
                    {
                        _currentSelection = 1;
                    }

                }
                else if (keyPressedCode == 12)  // enter
                {
                    run = false;
                }
                else if (keyPressedCode == 13)  // q for quit
                {
                    return -1;

                }
                // add more key options here with more else if statements
                // just make sure to add the case to your main switch statement

                DrawMenu();
            }

            return _currentSelection;
        }

        private void DrawMenu()
        {
            //string leftPointer = "    ";
            //string rightPointer = "    ";
            for (int i = 0; i < _options.Length; i++)
            {
                SetCursorPosition(_drawMenuRowPos + i, _drawMenuColumnPos);
                SetConsoleTextColor(ConsoleColor.White, ConsoleColor.Black);
                if (i == _currentSelection - 1)
                {
                    SetConsoleTextColor(ConsoleColor.Black, ConsoleColor.White);
                    //leftPointer = "  ► ";
                    //rightPointer = " ◄  ";

                }
                Console.WriteLine(_options[i]);
                //Console.WriteLine(leftPointer + _options[i] + rightPointer);
                //leftPointer = "    ";
                //rightPointer = "    ";
                ResetColor();
            }
        }

        private int CheckKeyPress()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            do
            {
                ConsoleKey keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    return 10;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    return 11;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    return 12;
                }
                else if (keyPressed == ConsoleKey.Q)
                {
                    return 13;
                }
                else
                {
                    return 0;
                }

            } while (true);
        }
    }
}