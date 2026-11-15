using Microsoft.EntityFrameworkCore;
using Tarea_4;

using var db = new HelperDbContext();
db.Database.EnsureCreated();

List<Paciente> Patients = db.Patients.ToList();
List<Doctor> Doctors = db.Doctors.ToList();
List<Cita> Appointments = db.Appointments
    .Include(c => c.RelatedDoctor)
    .Include(c => c.RelatedPatient)
    .ToList();
bool Continue = true;
int Option = 0;

do
{
    Console.WriteLine("Bienvenido al programa de gestión de citas");
    Console.WriteLine("Seleccione la tarea que desea realizar:\n1.Registrar nuevo paciente.\n2.Registrar nuevo doctor.\n3.Generar nueva cita.\n4.Modificar cita.\n5.Cancelar una cita.\n6.Lista de citas existentes.\n7.Abandonar el programa.");
    try
    {
        Option = int.Parse(Console.ReadLine());
    }
    catch (FormatException)
    {
        Option = 0;
    }
    switch (Option)
    {
        case 1:
            {
                Helper.AddPaciente(Patients);
                break;
            }
        case 2:
            {
                Helper.AddDoctor(Doctors);
                break;
            }
        case 3:
            {
                Helper.AddCita(Appointments, Patients, Doctors);
                break;
            }
        case 4:
            {
                Helper.EditCita(Appointments, Doctors);
                break;
            }
        case 5:
            {
                Helper.CancelCita(Appointments);
                break;
            }
        case 6:
            {
                Cita.ShowAll(Appointments);
                break;
            }
        case 7:
            {
                Continue = false;
                break;
            }
        default:
            {
                Console.WriteLine("La opción introducida no es valida, por favor, intente nuevamente");
                break;
            }
    }
    Helper.Save(db, Patients, Doctors, Appointments);
} while (Continue);
