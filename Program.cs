using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb1
{
    class Employer
    {
        public enum Position
        {
            Worker,
            Engineer,
            Supervisor,
            Director
        }
        private Position m_position;
        private string m_fullName;
        private int m_salary;
        private string m_district;
        List<Tuple<string,DateTime,Position>> m_career;
        private static bool IsNumberContains(string input)
        {
            foreach (char c in input)
                if (Char.IsNumber(c))
                    return true;
            return false;
        }
        private static bool IsLetterContains(string input)
        {
            foreach (char c in input)
                if (Char.IsLetter(c))
                    return true;
            return false;
        }
        private void validateName(string name)
        {
            if (name.Equals(String.Empty)) throw new ArgumentException("invalid name was provided");
            if (IsNumberContains(name)) throw new ArgumentException("invalid name was provided");
            m_fullName = name;
        }
        private void validateDistrict(string name)
        {
            if (!IsLetterContains(name)) throw new ArgumentException("invalid district was provided");
            if (!IsNumberContains(name)) throw new ArgumentException("invalid district was provided");
            m_district = name;
        }
        private void makeCareer(Position position,DateTime date, string district = "")
        {
            if (district == "") district = m_district;
            validateDistrict(district);
            m_position = position;
            m_career.Add(new Tuple<string, DateTime, Position>(district,date,position));
            switch(position)
            {
                case Position.Director:
                    m_salary = 50000;
                    break;
                case Position.Supervisor:
                    m_salary = 20000;
                    break;
                case Position.Engineer:
                    m_salary = 10000;
                    break;
                case Position.Worker:
                    m_salary = 5000;
                    break;
            }
        }
        private void changePosition(Position newPosition,DateTime date,string district="")
        {
            if (district == "") district = m_district;
            //TODO: make date optional
            makeCareer(newPosition,date,district);
        }
        private void decPosition(DateTime date,string district ="")
        {
            if (district == "") district = m_district;
            if (m_position == Position.Worker) return;
            makeCareer(--m_position, date);
        }
        private void incPosition(DateTime date,string district="")
        {
            if (district == "") district = m_district;
            if (m_position == Position.Director) return;
            makeCareer(++m_position, date);
        }
        private int getSalary()
        {
            return m_salary;
        }
        private void changeDistrict(string newDistrict)
        {
            makeCareer(m_position, DateTime.Today, newDistrict);
        }
        public Employer(string fullName, Position position, string district, DateTime date)
        {
            //TODO: make date optional
            validateName(fullName);
            makeCareer(position, date);
            validateDistrict(district);
            //TODO: catch exceptions
        }
        public Tuple<DateTime, string> findByPosition(Position position)
        {
            foreach(var i in m_career)
            {
                if (i.Item3 == position) return new Tuple<DateTime,string>(i.Item2, i.Item1);
            }
            return null;
        }

        public Tuple<DateTime, Position> findByDistrict(string district)
        {
            foreach (var i in m_career)
            {
                if (i.Item1 == district) return new Tuple<DateTime, Position>(i.Item2, i.Item3);
            }
            return null;
        }
    }

    class Program
    {
    }
}
//todo: toString conversion
//employers comparsion
//find
