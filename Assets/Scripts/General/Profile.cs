using System;
using UnityEngine.Analytics;

namespace Assets.Scripts
{
    public class Profile : IComparable<Profile>

    {
        public string Name { private set; get; }
        public int Age { private set; get; }
        public string Color { private set; get; }
        public Gender Gender { private set; get; }
        public string Ship { private set; get; }

        public Profile(string name, int age, string color, Gender gender, string ship)
        {
            Name = name;
            Age = age;
            Color = color;
            Gender = gender;
            Ship = ship;
        }

        public int CompareTo(Profile other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }
}