namespace Tarea_4
{
    public class Doctor
    {
        public Doctor() { }
        public Doctor(int id, string name, string area, long phonenumber, long document, string email)
        {
            Id = id;
            Name = name;
            Area = area;
            Phonenumber = phonenumber;
            Document = document;
            Email = email;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public long Phonenumber { get; set; }
        public long Document { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return $"{Id,-4}{Name,-30}{Area,-20}{Phonenumber,-15}{Email,-35}{Document,-15}";
        }
        public static void ShowAll(List<Doctor> doctors)
        {
            Console.WriteLine("A continuación se mostrarán los doctores listados:");
            Console.WriteLine($"{"ID",-4}{"Nombre",-30}{"Especialidad",-20}{"Teléfono",-15}{"Email",-35}{"Documento",-15}");
            foreach (Doctor d in doctors)
            {
                Console.WriteLine(d.ToString());
            }
        }
    }
}

