using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorthem;
namespace STAR_TEAM.Classes
{
    public class BaseClass
    {
        public static STARContext db = new STARContext();
        public static List<bool> TimesList;
        public static List<Class> CSelectedList = new List<Class>();
        public static List<Teacher> TSelectedList = new List<Teacher>();

        //<-- DB_Lists -->//
        public static Dictionary<byte, byte> Classes_ID_Dictionary = new Dictionary<byte, byte>();
        /*****************************************************************************************************/
        public static List<Teacher> DB_Teach = new List<Teacher>();
        public static List<Place> DB_Place = new List<Place>();
        public static List<Class> DB_Class = new List<Class>();
        public static List<Subject> DB_Sub = new List<Subject>();

        public static byte GenerateRandom()
        {
            Random random = new Random();
            byte r = Convert.ToByte(random.Next(0, 255));
            return r;
        }

        public void RunFunction()
        {
            //<-- Set Lists -->//
            DB_Teach = db.Teachers.ToList();
            DB_Place = db.Places.ToList();
            DB_Class = db.Classes.ToList();
            DB_Sub = db.Subjects.ToList();
            //<-- Trans Lists -->//
            TransLists();

            //<-- Calling... [ Algorithm Class ] -->//

        }

        //<-- Trans Lists -->//
        public void TransLists()
        {
            #region transforms
            #region teacher...
            foreach (var T in DB_Teach)
            {
                comman_class.teachers New_teach = new comman_class.teachers { teacher_ID = T.Teacher_ID };
                byte count = 1;
                string[] arr = T.TAvalabile_period.Split(',');
                foreach (var T2 in arr)
                {
                    if (T2[0] == 'T') { New_teach.avalabile_period.Add(count); }
                    count++;
                }
                comman_class.lis_teachers.Add(New_teach);
            }
            #endregion
            #region student
            foreach (var Stu in DB_Class)
            {
                var S = new comman_class.studients();
                byte count = 1;
                int Groube_ID = (((int)Stu.Class_Group[1] - 49) * 60 + ((int)Stu.Class_Group[0] - 65) * 10);
                for (int i = Groube_ID + 1; i < Groube_ID + 9; i++)
                {
                    if (comman_class.lis_students.Find(X => X.studient_ID == ++Groube_ID) == null)
                    { S.studient_ID = (byte)i; break; }
                }
                Classes_ID_Dictionary.Add(S.studient_ID, Stu.Class_ID);
                string[] arr = Stu.CAvalabile_period.Split(',');
                foreach (var T in arr)
                {
                    if (T[0] == 'T') { S.avalabile_period.Add(count); }
                    count++;
                }
                comman_class.lis_students.Add(S);
            }
            #endregion
            #region places
            foreach (var P in DB_Place)
            {
                var R = new comman_class.places().describtion_place;
                R.Add(Descr(P.PDescribtion_place));
                comman_class.Lis_places.Add(new comman_class.places { ID = P.Place_ID, describtion_place = R });
            }
            #endregion
            #region subjects
            foreach (var item in DB_Sub)
            {
                comman_class.subjects sub = new comman_class.subjects
                {
                    ID = item.Sub_ID,
                    IS_Group = item.Is_Group,
                    cource_by_week = (byte)item.Sub_Timebyweek
                };
                sub.Descreption_place.Add(Descr(item.SDescreption_place));
                
                foreach (var T in item.Sub_ClassList)
                {
                    var stu = comman_class.lis_students.Find(X => X.studient_ID == T.Class_ID);
                    sub.lis_sub_student_ID.Add(stu);
                }
                foreach (var T in item.Sub_ClassList)
                {
                    var stu = comman_class.lis_teachers.Find(X => X.teacher_ID == T.Class_ID);
                    sub.lis_sub_teachers_ID.Add(stu);
                }
                comman_class.lis_subject.Add(sub);
            }
            #endregion
            #endregion
            magdy.get_package();
        }
        byte Descr(string place_Type)
        {
            switch (place_Type)
            {
                case "Lecture": return 1; break;
                case "Section": return 2; break;
                case "Programming Lab.": return 3; break;
                case "Physical Lab.": return 4; break;
                default: return 5; break;
            }
        }
    }
}
namespace Algorthem
{
    public class comman_class
    {
        static public List<pack> Backs_Result = new List<pack>();
        static public List<teachers> lis_teachers = new List<teachers>();
        static public List<subjects> lis_subject = new List<subjects>();
        static public List<studients> lis_students = new List<studients>();
        static public List<places> Lis_places = new List<places>();
        public class pack
        {
            public byte time_period;
            public byte place;
            public byte teacher;
            public byte subject;
            public byte studients;
        }
        public class teachers
        {
            public byte teacher_ID;
            public byte pressure_by_day;
            public List<byte> avalabile_period = new List<byte>();
        }
        public class studients
        {
            public byte studient_ID;
            public bool IS_creadet = false;
            public List<byte> avalabile_period = new List<byte>();
        }
        public class places
        {
            public byte ID;
            public List<byte> describtion_place = new List<byte>();
            public List<byte> period_time_avalabile = new List<byte>();
        }
        public class subjects
        {
            public byte ID;
            public byte cource_by_week;
            public List<byte> Descreption_place = new List<byte>();
            public bool IS_Group;
            public List<studients> lis_sub_student_ID = new List<studients>();
            public List<teachers> lis_sub_teachers_ID = new List<teachers>();
        }
    }
    /* class Program
     {
         static void Main(string[] args)
         {

             #region random tabel
             #region get random number
             Random R = new Random();
             comman_class.studients Stu;
             for (byte i = 1; i <= 100; i++)
             {
                 Stu = new comman_class.studients();
                 Stu.studient_ID = (byte)R.Next(1, 200);
                 if (comman_class.lis_students.Find(X => X.studient_ID == Stu.studient_ID) == null & Stu.studient_ID % 10 != 0) comman_class.lis_students.Add(Stu);
                 else i--;
             }
             foreach (var r in comman_class.lis_students)
             {
                 r.IS_creadet = R.Next(1, 6) == 1 ? true : false;
                 int loop = R.Next(36, 42);
                 for (int i = 0; i < loop; i++)
                 {
                     byte av = (byte)R.Next(1, 42);
                     if (!r.avalabile_period.Contains(av)) r.avalabile_period.Add(av);
                     else i--;
                 }
                 r.avalabile_period.Sort();
             }
             comman_class.teachers tech;
             for (byte i = 1; i <= 30; i++)
             {
                 tech = new comman_class.teachers();
                 tech.teacher_ID = (byte)R.Next(1, 255);
                 if (comman_class.lis_teachers.Find(X => X.teacher_ID == tech.teacher_ID) == null) comman_class.lis_teachers.Add(tech);
                 else i--;
             }
             foreach (var r in comman_class.lis_teachers)
             {
                 int loop = R.Next(20, 25);
                 for (int i = 0; i < loop; i++)
                 {
                     byte av = (byte)R.Next(1, 42);
                     if (!r.avalabile_period.Contains(av)) r.avalabile_period.Add(av);
                     else i--;
                 }
                 r.avalabile_period.Sort();
             }
             comman_class.subjects subject;
             for (byte i = 1; i <= 74; i++)
             {
                 subject = new comman_class.subjects();
                 subject.ID = (byte)R.Next(1, 255);
                 subject.IS_Group = R.Next(1, 6) == 1;
                 subject.cource_by_week = (byte)R.Next(1, 3);
                 if (comman_class.subject.Find(X => X.ID == subject.ID) == null) comman_class.subject.Add(subject);
                 else i--;
             }
             for (byte i = 0; i < 74; i++)
             {
                 byte loop = (byte)R.Next(5, 16);
                 for (byte j = 1; j <= loop; j++)
                 {
                     int num = R.Next(0, 99);
                     if (comman_class.subject[i].lis_sub_student_ID.Find(X => X.studient_ID / 10 == num / 10) == null)
                     {
                         int new_num = num / 10;
                         foreach (var T in comman_class.lis_students)
                             if (T.studient_ID / 10 == new_num)
                             {
                                 comman_class.subject[i].lis_sub_student_ID.Add(T);
                                 j++;
                             }
                     }
                     else j--;
                 }
             }
             for (byte i = 0; i < 74; i++)
             {
                 // teacher
                 byte loop = (byte)R.Next(1, 6);
                 for (byte j = 1; j <= loop; j++)
                 {
                     int num = R.Next(0, 29);
                     if (!comman_class.subject[i].lis_sub_teachers_ID.Contains(comman_class.lis_teachers[num]))
                         comman_class.subject[i].lis_sub_teachers_ID.Add(comman_class.lis_teachers[num]);
                     else j--;
                 }
             }
             for (byte i = 0; i < 74; i++)
             {
                 // subject_places
                 byte loop = (byte)R.Next(2, 4);
                 for (byte j = 1; j <= loop; j++)
                 {
                     byte NEXT = (byte)R.Next(1, 10);
                     if (!comman_class.subject[i].Descreption_place.Contains(NEXT))
                         comman_class.subject[i].Descreption_place.Add((byte)R.Next(1, 10));
                     else j--;
                 }
             }
             comman_class.lis_students = comman_class.lis_students.OrderBy(X => X.studient_ID).ToList();
             comman_class.lis_teachers = comman_class.lis_teachers.OrderBy(X => X.teacher_ID).ToList();
             comman_class.subject = comman_class.subject.OrderBy(X => X.ID).ToList();
             {
                 int looop = R.Next(20, 30);
                 for (int i = 0; i < looop; i++)
                 {
                     byte num1 = (byte)R.Next(10, 99);
                     if (comman_class.Lis_places.Find(X => X.ID == num1) == null)
                     {
                         var RT = new comman_class.places();
                         for (int i2 = 0; i2 < 6; i2++)
                         {
                             byte NEXT = (byte)R.Next(1, 10);
                             if (!RT.describtion_place.Contains(NEXT))
                                 RT.describtion_place.Add(NEXT);
                             else i2--;
                         }
                         RT.ID = num1;
                         comman_class.Lis_places.Add(RT);
                     }
                     else i--;
                 }
             }
             #endregion
             // out put
             magdy.get_package();
             #endregion
         }
     }*/
    class magdy
    {
        #region values
        class _pack : comman_class.pack
        {
            public __ cource_by_week;
            public List<byte> Descreption_place = new List<byte>();
            public bool IS_creadet;
        }
        class __
        {
            public byte value;
        }
        class Block_num
        {
            public _pack block;
            public short count;
        }
        static List<_pack> all_probabilty_packs = new List<_pack>();
        static List<Block_num> list_for_easy_search = new List<Block_num>();
        static List<Block_num> rabsh = new List<Block_num>();
        static int counter;
        static int counter2 = 0;
        #endregion
        static public void get_package()
        {
            //form_packs();
            output();
            return;
            Console.WriteLine(all_probabilty_packs.Count);
            while (all_probabilty_packs.Count > 0)
                processing();
            #region checck for error

            /*foreach (var item1 in comman_class.Backs_Result)
            {
                var R = list_for_easy_search.Find(X => item1.studients == X.block.studients);
                if (R != null)
                {
                    R.count--;
                    Console.WriteLine("{4}) [{0} {1} {2}] {3}", R.block.studients, R.block.teacher, R.block.subject, R.count, __C__++);
                }
                R = list_for_easy_search.Find(X => item1.teacher == X.block.teacher);
                if (R != null)
                {
                    R.count--;
                    Console.WriteLine("{4}) [{0} {1} {2}] {3}", R.block.studients, R.block.teacher, R.block.subject, R.count, __C__++);
                }
                R = list_for_easy_search.Find(X => item1.subject == X.block.subject);
                if (R != null)
                {
                    R.count--;
                    Console.WriteLine("{4}) [{0} {1} {2}] {3}", R.block.studients, R.block.teacher, R.block.subject, R.count, __C__++);
                }
            }*/
            Console.WriteLine("==================");
            Console.WriteLine("==================");
            Console.WriteLine("==================");
            /*foreach (var item in list_for_easy_search)
            {
                Console.WriteLine("[{0} {1} {2}] {3}", item.block.studients, item.block.teacher, item.block.subject, item.count);
            }*/
            //Console.WriteLine("\n\n\n\n\n\n\n");

            Console.WriteLine(all_probabilty_packs.Count + "\n\n\n\n");
            int summations = 0;
            int summations2 = 0;
            foreach (var t in list_for_easy_search)
            {
                int C = comman_class.Backs_Result.FindAll(X => X.subject == t.block.subject & X.studients == t.block.studients & X.teacher == t.block.teacher).Count;
                if (C == 0)
                { Console.WriteLine("[{0} {1} {2} ] {3}", t.block.studients, t.block.teacher, t.block.subject, t.count); summations2 += 1; }
                else if (C == 1) { Console.WriteLine(" ----1--- [{0} {1} {2}] {3}", t.block.studients, t.block.teacher, t.block.subject, t.count); summations += 1; }
                else if (C == 2) { Console.WriteLine(" ----2--- [{0} {1} {2}] {3}", t.block.studients, t.block.teacher, t.block.subject, t.count); summations += 1; }
            }
            Console.WriteLine(" total subject avalabile {1}\ntotal courses by week {0}\nsubject's loses {2}"
                , comman_class.Backs_Result.Count
                , summations
                , summations2);
            /*
            foreach (var t in comman_class.Backs_Result)
            {
                Console.WriteLine("[{0} {1} {2}] ", t.subject, t.studients, t.teacher);
            }*/
            foreach (var Check in comman_class.Backs_Result)
            {
                var OUT = comman_class.Backs_Result.FindAll(X => X.studients == Check.studients & X.time_period == Check.time_period);
                if (OUT.Count > 1) { Console.WriteLine("Error 1"); break; }
            }
            foreach (var Check in comman_class.Backs_Result)
            {
                var OUT = comman_class.Backs_Result.FindAll(X => X.teacher == Check.teacher & X.time_period == Check.time_period);
                if (OUT.Count > 1) { Console.WriteLine("Error 2"); break; }
            }
            foreach (var Check in comman_class.Backs_Result)
            {
                var OUT = comman_class.Backs_Result.FindAll(X => X.place == Check.place & X.time_period == Check.time_period);
                if (OUT.Count > 1) { Console.WriteLine("Error 3"); return; }
            }
            Console.WriteLine("clear");
            //Console.ReadKey();
            #endregion
        }
        static void output()
        {
            byte OUT = 10;
            if (OUT == 1 | OUT == 10) foreach (var r in comman_class.lis_students)
                {
                    Console.WriteLine("studient " + r.studient_ID);
                    foreach (var n in r.avalabile_period)
                        Console.WriteLine("   " + n);
                }
            Console.WriteLine("----------------");
            if (OUT == 2 | OUT == 10) foreach (var r in comman_class.lis_teachers)
                {
                    Console.WriteLine("teacher " + r.teacher_ID);
                    foreach (var n in r.avalabile_period)
                        Console.WriteLine("      " + n);
                }
            Console.WriteLine("----------------");
            if (OUT == 3 | OUT == 10) foreach (var r in comman_class.lis_subject)
                {
                    if (r.IS_Group)
                    {
                        Console.WriteLine("mada {0}  {1} {2} ", r.ID, r.IS_Group, r.cource_by_week);
                        foreach (var N in r.lis_sub_teachers_ID)
                            Console.WriteLine("   M " + N.teacher_ID);
                        Console.WriteLine();
                        foreach (var N in r.lis_sub_student_ID)
                            Console.WriteLine("   T " + N.studient_ID);
                    }
                }
            Console.WriteLine("----------------");
            if (OUT == 4 | OUT == 10) foreach (var item in comman_class.Lis_places)
                {
                    Console.WriteLine("{0} Des : {1} ", item.ID, item.describtion_place[0]);
                }
        }
        static void form_packs()
        {
            bool IS_OUTPUT = false;
            /********************* formed groube ID ***************************/
            List<comman_class.studients> copy_stu_lis = new List<comman_class.studients>(comman_class.lis_students);
            foreach (var T in copy_stu_lis)
            {
                if (comman_class.lis_students.Find(X => (byte)(T.studient_ID / 10 * 10) == X.studient_ID) == null)
                {
                    comman_class.lis_students.Add(new comman_class.studients() { studient_ID = (byte)(T.studient_ID / 10 * 10) });
                }
            }
            /****************************************************************/

            /************* add comman period time for groube ****************/
            for (int i = 0; i < copy_stu_lis.Count; i++)
            {
                int _1 = i > 0 ? 1 : 0;
                comman_class.studients T1 = copy_stu_lis[i];
                if (T1.studient_ID / 10 == copy_stu_lis[i - _1].studient_ID / 10 & _1 != 0) continue;
                foreach (var p in T1.avalabile_period)
                {
                    bool IS_reapet = true;
                    foreach (var T2 in copy_stu_lis)
                    {
                        if (T1.studient_ID / 10 != T2.studient_ID / 10) continue;
                        if (T1.studient_ID % 10 == 0 | T2.studient_ID % 10 == 0) continue;
                        IS_reapet = T2.avalabile_period.Contains(p) ? IS_reapet : false;
                    }
                    if (IS_reapet)
                    {
                        comman_class.studients ST = comman_class.lis_students.Find(X => X.studient_ID == T1.studient_ID / 10 * 10);
                        if (!ST.avalabile_period.Contains(p)) ST.avalabile_period.Add(p);
                    }
                }
            }
            /****************************************************************/
            #region OUT PUT

            if (IS_OUTPUT) foreach (var T in comman_class.lis_teachers)
                {
                    Console.Write("{0} (", T.teacher_ID);
                    foreach (var per in T.avalabile_period)
                        Console.Write(" " + per);
                    Console.WriteLine(")");
                }      // Output
            if (IS_OUTPUT) foreach (var T in comman_class.lis_students)
                {
                    Console.Write("{0} (", T.studient_ID);
                    foreach (var per in T.avalabile_period)
                        Console.Write(" " + per);
                    Console.WriteLine(")");
                }      // Output

            #endregion
            /***************************************************************/
            /// bna5od kol mada bttdares fe groube oe n5le kol ID grobe el hoa byt2esem 3ala 10
            foreach (var list in comman_class.lis_subject)
            {
                if (list.IS_Group)
                {
                    while (list.lis_sub_student_ID[0].studient_ID % 10 != 0)
                    {
                        //Console.WriteLine(list.lis_sub_student_ID[0].studient_ID);
                        var item = list.lis_sub_student_ID[0];
                        if (list.lis_sub_student_ID.Find(X => X.studient_ID == item.studient_ID / 10 * 10) == null)
                        {
                            var St = comman_class.lis_students.Find(X => X.studient_ID == item.studient_ID / 10 * 10);
                            list.lis_sub_student_ID.Add(St);
                        }
                        list.lis_sub_student_ID.Remove(item);
                    }
                }
            }
            /****************************************************************/
            foreach (var mada in comman_class.lis_subject)
            {
                List<comman_class.studients> stu_copy = new List<comman_class.studients>(mada.lis_sub_student_ID);
                List<comman_class.teachers> tech_copy = new List<comman_class.teachers>(mada.lis_sub_teachers_ID);
                while (stu_copy.Count > 0)
                {
                    foreach (var teacher in tech_copy)
                    {
                        comman_class.studients S = null;
                        _pack Block = new _pack();
                        Block.cource_by_week = new __();
                        Block.cource_by_week.value = Block.IS_creadet ? (byte)(mada.cource_by_week * 2) : mada.cource_by_week;
                        var COMMAN = Block.cource_by_week;
                        int _counter = -1, counter = 0;
                        foreach (var studient in stu_copy)
                        {
                            #region count avalabile period comman by student and teachers
                            foreach (var per_teacher in teacher.avalabile_period)
                                foreach (var per_studeint in studient.avalabile_period)
                                    if (per_teacher == per_studeint) counter++;
                            #endregion
                            if (counter > _counter & counter > 0)
                            {
                                Block.studients = studient.studient_ID;
                                S = studient;
                                _counter = counter;
                            }
                            counter = 0;
                        }
                        if (_counter == -1) continue;
                        foreach (var i in teacher.avalabile_period)
                            foreach (var j in S.avalabile_period)
                                if (i == j)
                                {
                                    Block.studients = S.studient_ID;
                                    Block.IS_creadet = S.IS_creadet;
                                    Block.time_period = i;
                                    Block.cource_by_week = COMMAN;

                                    Block.Descreption_place = mada.Descreption_place;
                                    Block.teacher = teacher.teacher_ID;
                                    Block.subject = mada.ID;
                                    all_probabilty_packs.Add(Block);
                                    if (all_probabilty_packs.Count == 1) list_for_easy_search.Add(new Block_num { block = Block, count = 1 });
                                    else
                                    {
                                        var item1 = list_for_easy_search[magdy.counter].block;
                                        if (item1.subject == Block.subject & item1.teacher == Block.teacher & item1.studients == Block.studients)
                                            list_for_easy_search[magdy.counter].count++;
                                        else
                                        {
                                            magdy.counter++;
                                            list_for_easy_search.Add(new Block_num { block = Block, count = 1 });
                                        }
                                    };
                                    Block = new _pack();
                                }
                        stu_copy.Remove(S);
                        if (stu_copy.Count == 0) break;
                    }
                }
            }        // distribute subjects 
            foreach (var T in comman_class.Lis_places)
            {
                for (byte i = 1; i <= 42; i++)
                {
                    T.period_time_avalabile.Add(i);
                }
            }
            #region OUTPUT
            if (IS_OUTPUT) foreach (var T in comman_class.lis_subject)
                {
                    foreach (var Item in T.Descreption_place)
                        Console.Write(Item + " ");
                    Console.WriteLine();
                }
            if (IS_OUTPUT) foreach (var T in comman_class.lis_subject)
                {
                    Console.WriteLine(T.cource_by_week);
                }
            Console.WriteLine("---------------\nlist places\n---------------");
            if (IS_OUTPUT) foreach (var T in comman_class.Lis_places)
                {
                    Console.Write("description ");
                    foreach (var item in T.describtion_place)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                    Console.Write("period_time ");
                    foreach (var item in T.period_time_avalabile)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
            if (IS_OUTPUT) foreach (var T in comman_class.Lis_places)
                {
                    Console.WriteLine(T.ID);
                    if (comman_class.Lis_places.FindAll(X => X.ID == T.ID).Count > 1) Console.WriteLine("Error");
                }               // output
            if (IS_OUTPUT) foreach (var T in list_for_easy_search)
                {
                    Console.WriteLine("[{0} {1} {2} - {3}] {4}", T.block.studients, T.block.teacher, T.block.subject, T.block.time_period, T.count);
                }
            if (IS_OUTPUT) foreach (var T in all_probabilty_packs)
                {
                    Console.WriteLine("teacher {0} , student {1} , comman time {2} , mada {3} , IS group {4} "
                        , T.teacher.ToString().PadRight(3), T.studients.ToString().PadRight(3),
                        T.time_period.ToString().PadRight(3), T.subject.ToString().PadRight(3), T.studients % 10 == 0);
                }           //Output 
            #endregion
        }
        static void processing()
        {
            #region sort
            var _list_for_easy_search = new List<Block_num>(list_for_easy_search);
            list_for_easy_search.Clear();
            while (_list_for_easy_search.Count > 0)
            {
                var vAR = _list_for_easy_search[0];
                var _vAR = vAR;
                while (_vAR != null)
                {
                    vAR = _vAR;
                    _vAR = _list_for_easy_search.Find(X =>
((float)(X.count + 1) * 2 / (float)X.block.cource_by_week.value + .001) < ((float)(vAR.count + 1) * 2 / (float)(vAR.block.cource_by_week.value + .001))
                          & X.count > 0 & X.block.cource_by_week.value > 0);

                }
                list_for_easy_search.Add(vAR);
                _list_for_easy_search.Remove(vAR);
            }
            #endregion
            #region Get for all pack of one kind
            var _copy = new List<_pack>();
            {
                var T = list_for_easy_search[0];
                foreach (var item in list_for_easy_search)
                {
                    if (item.count > 0) { T = item; /*item.count = 0;*/ break; }
                }
                bool __ = false;
                foreach (var item in all_probabilty_packs)
                {
                    if (item.studients == T.block.studients & item.teacher == T.block.teacher & item.subject == T.block.subject)
                    {
                        __ = true; _copy.Add(item);
                    }
                    else __ = false;
                    if (__ == false & _copy.Count > 0) break;
                }
            }
            List<_pack> _copy_copy = new List<_pack>(_copy);
            int COUNT = _copy_copy.Count;
            _copy = _copy.FindAll(X => X.time_period % 2 == 1 & _copy.Find(X1 => X1.time_period == X.time_period + 1) != null
                | X.time_period % 2 == 0 & _copy.Find(X1 => X1.time_period == X.time_period - 1) != null);
            if (!_copy_copy[0].IS_creadet & _copy_copy.Count > _copy.Count)
            {
                foreach (var item in _copy)
                    if (_copy_copy.Contains(item)) { _copy_copy.Remove(item); }
                _copy = _copy_copy;
            }
            else if (!_copy_copy[0].IS_creadet)
            {
                _copy = _copy_copy;
            }
            else if (_copy.Count == 0)
            {
                foreach (var item in _copy_copy)
                {
                    all_probabilty_packs.Remove(item);
                    var TT = list_for_easy_search.Find(X => X.block.studients == item.studients
                                                 & X.block.teacher == item.teacher
                                                 & X.block.subject == item.subject);
                    if (TT != null) TT.count--;

                }
                return;
            }
            bool _IS_ = _copy[0].studients % 10 == 0;
            var Class_in_Groube = comman_class.lis_students.FindAll(x => x.studient_ID / 10 == _copy[0].studients / 10 & x.studient_ID % 10 != 0);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //    Console.WriteLine(COUNT);                                                                                             //
            //    Console.WriteLine(_copy_copy.Count);                                                                                  //
            //    Console.WriteLine(_copy.Count);                                                                                       //
            // foreach (var item in list_for_easy_search)                                                                               //
            // {                                                                                                                        //
            //     Console.WriteLine("[{0} {1} {2}] {3} / {4} {5}"                                                                      //
            //         , item.block.studients, item.block.teacher, item.block.subject, item.block.cource_by_week.value,item.count       //
            //         ,item.block.IS_creadet.ToString().PadLeft(10));                                                                  //
            // }                                                                                                                        //
            // Console.WriteLine("\n\n-----------------\n\n");                                                                          //
            // Console.ReadKey();                                                                                                       //
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            //foreach (var i in _copy)                                                                              //
            //{                                                                                                     //
            //    Console.Write("{0} {1} {2} - {3} [", i.studients , i.teacher, i.subject , i.time_period);         //
            //    foreach (var item in i.Descreption_place)                                                         //
            //    {                                                                                                 //
            //        Console.Write("{0} ", item);                                                                  //
            //    }                                                                                                 //
            //    Console.WriteLine("]");                                                                           //
            //}                                                                                                     //
            //Console.WriteLine();                                                                                  //
            //Console.ReadKey();                                                                                    //
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            #endregion
            #region get all places description
            var list_place = new List<comman_class.places>();
            List<byte> _copy_all_av_time = new List<byte>();
            foreach (var item1 in _copy)
                _copy_all_av_time.Add(item1.time_period);
            int Blus = _copy[0].IS_creadet ? 1 : 0;
            for (int j = 0; j < _copy.Count - Blus; j += Blus + 1)
            {
                var X = _copy[j].time_period;
                var Y = _copy[j + Blus].time_period;
                foreach (var R in comman_class.Lis_places)
                {
                    if (R.period_time_avalabile.Contains(X) & R.period_time_avalabile.Contains(Y))
                    {
                        bool __ = true;
                        foreach (var R2 in _copy[j].Descreption_place)
                        {
                            if (!R.describtion_place.Contains(R2)) __ = false;
                        }
                        if (__) list_place.Add(R);
                    }
                }
            }
            /***************************************************/
            if (list_place.Count == 0)  /// if don't find place for package
            {
                Console.WriteLine("lose pack [T = {0}, S = {1}, Subj = {2} , time by weak {3} ] because of no place"
                    , _copy[0].teacher, _copy[0].studients, _copy[0].subject, _copy[0].cource_by_week.value);
                foreach (var Y in _copy)
                {
                    var TT = list_for_easy_search.Find(X => X.block.studients == Y.studients
                                                           & X.block.teacher == Y.teacher
                                                           & X.block.subject == Y.subject);
                    if (TT != null) TT.count--;
                    all_probabilty_packs.Remove(Y);
                }
                return;
            }
            //////////////////////////////////////////////////////////////////
            //foreach (var item in list_place)                              //
            //{                                                             //
            //    Console.Write("{0} des ",item.ID);                        //
            //    foreach (var i in item.describtion_place)                 //
            //    {                                                         //
            //        Console.Write("{0} " , i);                            //
            //    }                                                         //
            //    Console.Write("\n{0} time ",item.ID);                     //
            //    foreach (var i in item.period_time_avalabile)             //
            //    {                                                         //
            //        Console.Write("{0} " , i);                            //
            //    }                                                         //
            //    Console.WriteLine("\n");                                  //
            //}                                                             //
            //////////////////////////////////////////////////////////////////
            List<byte> Lis = new List<byte>();
            foreach (var item in _copy)
                Lis.Add(item.time_period);
            #endregion
            #region Choose element
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            //foreach (var i in _copy)                                                                             //
            //{                                                                                                    //
            //    Console.Write("{0} {1} {2} - {3} [ ", i.studients, i.teacher, i.subject, i.time_period);         //
            //    foreach (var item in i.Descreption_place)                                                        //
            //    {                                                                                                //
            //        Console.Write("{0} ", item);                                                                 //
            //    }                                                                                                //
            //    Console.WriteLine("] {0}", i.IS_creadet);                                                        //
            //}                                                                                                    //
            //Console.ReadKey();                                                                                   //
            //Console.WriteLine();                                                                                 //
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            //foreach (var item in list_place)                                                                     //
            //{                                                                                                    //
            //    Console.Write("{0} des ", item.ID);                                                              //
            //    foreach (var i in item.describtion_place)                                                        //
            //    {                                                                                                //
            //        Console.Write("{0} ", i);                                                                    //
            //    }                                                                                                //
            //    Console.Write("\n{0} time ", item.ID);                                                           //
            //    foreach (var i in item.period_time_avalabile)                                                    //
            //    {                                                                                                //
            //        Console.Write("{0} ", i);                                                                    //
            //    }                                                                                                //
            //    Console.WriteLine("\n");                                                                         //
            //}                                                                                                    //
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            var Chose_item_place = list_place[0];
            var _Same_ = comman_class.Backs_Result.FindAll(X => X.studients == _copy[0].studients & X.teacher == _copy[0].teacher & X.subject == _copy[0].subject);
            List<byte> pers = new List<byte>();
            foreach (var T in _Same_)
                pers.Add((byte)(T.time_period / 6));
            foreach (var item in list_place)
            {
                if (item.period_time_avalabile.Count > Chose_item_place.period_time_avalabile.Count)
                    Chose_item_place = item;
            }
            _pack IteM = _copy[0], IteM2 = _copy[0];
            byte Time1 = 0, Time2 = 0;
            int Blus2 = _copy[0].IS_creadet ? 1 : 0;
            for (int j = 0; j < _copy.Count - Blus2; j += Blus2 + 1)
            {
                var X = _copy[j].time_period;
                var Y = _copy[j + Blus2].time_period;
                var ava = (byte)(_copy[j].time_period / 6);
                if (Chose_item_place.period_time_avalabile.Contains(X) & Chose_item_place.period_time_avalabile.Contains(Y) & !pers.Contains(ava))
                {
                    IteM = _copy[j];
                    Time1 = X;
                    IteM.place = Chose_item_place.ID;
                    IteM2 = _copy[j + Blus2];
                    Time2 = Y;
                    IteM2.place = Chose_item_place.ID;
                }
            }
            /////////////////////////////////////////////////////////////////////////
            //Console.Write(Chose_item_place.ID + "=> ");                          //
            //foreach (var item in Chose_item_place.period_time_avalabile)         //
            //{                                                                    //
            //    Console.Write(" " + item);                                       //
            //}                                                                    //
            //Console.WriteLine();                                                 //
            /////////////////////////////////////////////////////////////////////////
            Chose_item_place.period_time_avalabile.Remove(Time1);
            Chose_item_place.period_time_avalabile.Remove(Time2);
            ////////////////////////////////////////////////////////////////////////
            //Console.Write(Chose_item_place.ID + "=> ");                         //
            //foreach (var item in Chose_item_place.period_time_avalabile)        //
            //{                                                                   //
            //    Console.Write(" " + item);                                      //
            //}                                                                   //
            //Console.WriteLine();                                                //
            ////////////////////////////////////////////////////////////////////////
            if (Time1 == Time2)
            {
                /* Console.WriteLine("[{0} {1} {2} {3}] {4} "
                     , IteM.studients, IteM.teacher, IteM.place, IteM.subject,IteM.time_period);*/
                if (_IS_)
                    foreach (var T in Class_in_Groube)
                    {
                        var R = new comman_class.pack
                        {
                            place = IteM.place,
                            teacher = IteM.teacher,
                            subject = IteM.subject,
                            time_period = IteM.time_period
                        };
                        R.studients = T.studient_ID;
                        comman_class.Backs_Result.Add(R);
                    }
                else comman_class.Backs_Result.Add(IteM);
            }
            else
            {
                /*Console.WriteLine("[{0} {1} {2} {3}] {4} "
                   , IteM.studients, IteM.teacher, IteM.place, IteM.subject, IteM.time_period);
                Console.WriteLine("[{0} {1} {2} {3}] {4} "
                   , IteM2.studients, IteM2.teacher, IteM2.place, IteM2.subject, IteM2.time_period);*/
                if (_IS_)
                    foreach (var T in Class_in_Groube)
                    {
                        var R = new comman_class.pack
                        {
                            place = IteM.place,
                            teacher = IteM.teacher,
                            subject = IteM.subject,
                            time_period = IteM.time_period
                        };
                        R.studients = T.studient_ID;
                        comman_class.Backs_Result.Add(R);
                    }
                else comman_class.Backs_Result.Add(IteM);
                if (_IS_)
                    foreach (var T in Class_in_Groube)
                    {
                        var R = new comman_class.pack
                        {
                            place = IteM2.place,
                            teacher = IteM2.teacher,
                            subject = IteM2.subject,
                            time_period = IteM2.time_period
                        };
                        R.studients = T.studient_ID;
                        comman_class.Backs_Result.Add(R);
                    }
                else comman_class.Backs_Result.Add(IteM2);
            }
            #endregion
            #region DeletE
            /*{
                foreach (var T in _copy)
                    Console.Write(T.time_period + " ");
                Console.WriteLine();
                foreach (byte TY in T_place.period_time_avalabile)
                    Console.Write(TY + " ");
                Console.WriteLine("\n----------------");
                //Console.ReadKey();
            }*/
            //comman_class.Backs_Result.Add(IteM);
            IteM.cource_by_week.value--;
            Predicate<_pack> Search_for_delete = (X =>
                    ((X.studients / 10 == IteM.studients / 10) & IteM.studients % 10 == 0 & IteM.time_period == X.time_period) // if it is groube in same time
                    | ((X.studients == IteM.studients) & IteM.time_period == X.time_period)     // if just one class in same time
                    | (IteM.teacher == X.teacher & IteM.time_period == X.time_period)           // same teacher in same time
                    | (X.studients == IteM.studients & IteM.teacher == X.teacher & IteM.subject == X.subject & IteM.cource_by_week.value == 0));   // if same block

            //Console.WriteLine("->{0}<-",IteM.cource_by_week.value);
            var Deleting = all_probabilty_packs.Find(Search_for_delete);
            while (Deleting != null)
            {
                var TT = list_for_easy_search.Find(X => X.block.studients == Deleting.studients
                                                        & X.block.teacher == Deleting.teacher
                                                        & X.block.subject == Deleting.subject);

                if (TT != null) TT.count--;
                //Console.WriteLine(" <[stu = {0} , tech =  {1} , time = {2}]> ", DeletE.studients, DeletE.teacher, DeletE.time_period);
                all_probabilty_packs.Remove(Deleting);
                Deleting = all_probabilty_packs.Find(Search_for_delete);
            }

            if (_copy[0].IS_creadet)
            {
                IteM2.cource_by_week.value--;
                Predicate<_pack> Search_for_delete1 = (X =>
                    ((X.studients / 10 == IteM2.studients / 10) & IteM2.studients % 10 == 0 & IteM2.time_period == X.time_period) // if it is groube in same time
                    | ((X.studients == IteM2.studients) & IteM2.time_period == X.time_period)     // if just one class in same time
                    | (IteM2.teacher == X.teacher & IteM2.time_period == X.time_period)           // same teacher in same time
                    | (X.studients == IteM2.studients & IteM2.teacher == X.teacher & IteM2.subject == X.subject & IteM2.cource_by_week.value == 0));   // if same block
                var Deleting1 = all_probabilty_packs.Find(Search_for_delete1);
                while (Deleting1 != null)
                {
                    var TT = list_for_easy_search.Find(X => X.block.studients == Deleting1.studients
                                                                & X.block.teacher == Deleting1.teacher
                                                                & X.block.subject == Deleting1.subject);
                    if (TT != null) TT.count--;
                    // Console.WriteLine("[{0} {1} {2}] {3}", TT.block.studients, TT.block.teacher, TT.block.time_period, TT.count);

                    //Console.WriteLine(" <[stu = {0} , tech =  {1} , time = {2}]> ", Deleting1.studients, Deleting1.teacher, Deleting1.time_period);
                    all_probabilty_packs.Remove(Deleting1);
                    Deleting1 = all_probabilty_packs.Find(Search_for_delete1);
                }
            }
            //Console.WriteLine("2");
            #endregion
            while (counter2 < comman_class.Backs_Result.Count)
            {
                var OUT = comman_class.Backs_Result[counter2++];
                var OUT2 = comman_class.Backs_Result.FindAll(X => X.place == OUT.place & X.time_period == OUT.time_period);
                if (_IS_) Console.Write("taleb = {0}      teacher = {1}        mada = {2}         time per = {3}         place = {4}"
                                  , OUT.studients.ToString().PadLeft(3), OUT.teacher.ToString().PadLeft(3)
                                  , OUT.subject.ToString().PadLeft(3), OUT.time_period.ToString().PadLeft(3)
                                  , OUT.place.ToString().PadLeft(3));
                //if (OUT2.Count > 1) { Console.WriteLine("Error 2"); Console.ReadKey(); }
                Console.WriteLine();//"\n"+comman_class.Backs_Result.Count+"\n");
            }

            //Console.ReadKey();
        }
    }
}
// supose that every group study same subject untill input were full
// subjects without students or teachers 
// grouped subject repeated 1 st only 
// creadet card
