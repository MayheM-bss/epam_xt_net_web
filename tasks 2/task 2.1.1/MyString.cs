using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2._1._1
{
    class MyString
    {
        private readonly char[] Text;

        public int Lenght
        {
            get
            {
                return Text.Length;
            }
        }

        public char this[int i]
        {
            get
            {
                return Text[i];
            }
        }
        
        public int this [char i]
        {
            get
            {
                for (int j = 0; j < Text.Length; j++)
                {
                    if (Text[j] == i)
                    {
                        return j;
                    }
                }
                return -1;
            }
        }

        public MyString(string value)
        {
            Text = value.ToCharArray();
        }

        public override string ToString()
        {
            return new string(Text);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is MyString i)
            {
                return Equals(i);
            }
            return false;
        }

        public static MyString Concat (MyString string1, MyString string2)
        {
            return new MyString(string1.ToString() + " " + string2.ToString());
        }

        public static bool Equals (MyString string1, MyString string2)
        {
            return string1.ToString() == string2.ToString();
        }

        public static bool Contains (MyString str, char symb)
        {
            return str.ToString().Contains(symb);
        }

        public MyString Replace (MyString string1, MyString string2)
        {
            return new MyString(ToString().Replace(string1.ToString(), string2.ToString()));
        }

        public MyString Remove(int index)
        {
            char[] temp = new char[index];
            for (int i = 0; i < index; i++)
            {
                temp[i] = Text[i];
            }
            return new MyString(new string(temp));
        }

        public bool Equals (MyString str)
        {
            if(Text.Length == str.Text.Length)
            {
                for (int i = 0; i < Text.Length; i++)
                {
                    if(Text[i] != str.Text[i])
                    {
                        return false;
                    }    
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public MyString Concat(MyString str)
        {
            StringBuilder result = new StringBuilder();
            result.Append(Text);
            result.Append(' ');
            result.Append(str.Text);
            return new MyString(result.ToString());
        }

        public bool Contains(char symb)
        {
            foreach(char item in Text)
            {
                if (item == symb)
                {
                    return true;
                }
            }
            return false;
        }

        public MyString Slice (int startIndex, int endIndex)
        {
           if (endIndex < startIndex)
           {
                int c = startIndex;
                startIndex = endIndex;
                endIndex = c;
           }
           if (endIndex - startIndex == 0)
           {
                return new MyString("");
           }
           else
           {
                char[] temp = new char[endIndex - startIndex];
                for (int i = 0; i < endIndex - startIndex; i++)
                {
                    temp[i] = Text[startIndex + i];
                }
                return new MyString(new string(temp));
           }
        }

        public MyString SwapCase ()
        {
            char[] temp = new char[Text.Length];
            for (int i = 0; i < Text.Length; i++)
            {
                if(char.IsLetter(Text[i]) && char.IsLower(Text[i]))
                {
                    temp[i] = char.ToUpper(Text[i]);
                }
                else if (char.IsLetter(Text[i]) && char.IsUpper(Text[i]))
                {
                    temp[i] = char.ToLower(Text[i]);
                }
                else
                {
                    temp[i] = Text[i];
                }
            }
            return new MyString(new string(temp));
        }

        public char[] ToCharArray()
        {
            return Text;
        }

        public static implicit operator MyString(string value)
        {
            return new MyString(value);
        }

        public static MyString operator + (MyString string1, MyString string2)
        {
            return Concat(string1, string2);
        }
        
        public static bool operator == (MyString string1, MyString string2)
        {
            return Equals(string1, string2);
        }

        public static bool operator != (MyString string1, MyString string2)
        {
            return !Equals(string1, string2);
        }
    }
}
