using System;

abstract class TaskBase{
    public int id;
    public string title;

    public bool isComplated;
    public TaskBase(int id, string title, bool isComplated){
        this.id = id;
        this.title = title;
        this.isComplated =isComplated;
    }
    public abstract void Print();
}


class TaskItem : TaskBase{
    public DateTime createdAt;
    public TaskItem(int id, string title)
    :base(id,title,false){
        this.createdAt=DateTime.Now;
    }

    public override void Print(){
        Console.WriteLine($"Task id: {id} || Task Title: {title} || Task Status: {isComplated} || Task's Created Time: {createdAt}");
    }
}

static class TaskManager{
    public static TaskItem[] tasks = new TaskItem[0]; 

    public static void AddTask(ref TaskItem[] tasks){
        Console.WriteLine("Taskin id-si nedir:");
        int nid = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Taskin adi nedir:");
        string? ntitle = Console.ReadLine();
        if (string.IsNullOrEmpty(ntitle)) {
            Console.WriteLine("Task adı boş ola bilməz!");
            return;
        }
        TaskItem newTask = new TaskItem(nid, ntitle);

        Array.Resize(ref tasks, tasks.Length + 1);

        tasks[tasks.Length - 1] = newTask;

    }

    public static void ShowTasks(TaskItem[] tasks){
        foreach (var task in tasks)
        {
            task.Print();
        }
    }

    public static void TaskStatusChanger(TaskItem[] tasks){
        Console.WriteLine("Tamamladiginiz taskin id-si nedir:");
        int nid = Convert.ToInt32(Console.ReadLine());
        foreach (var task in tasks)
        {
            if(task.id==nid){
                task.isComplated=true;
                System.Console.WriteLine($"{task.id}-IDli Task ugurla tamamlandi");
            }
        }
    }

    public static void TaskRemover(ref TaskItem[] tasks){
        Console.WriteLine("Silmek istediyiniz taskin id-si nedir:");
        int nid = Convert.ToInt32(Console.ReadLine());
        foreach (var task in tasks)
        {
            if(task.id==nid){
                for (int i = 0; i < tasks.Length - 1; i++)
                {
                    tasks[i] = tasks[i + 1];
                }

                Array.Resize(ref tasks, tasks.Length - 1);
            }
        }
    }
}
class Program{

    static void Main(){
        int lamp = 1;
        TaskItem[] tasks = new TaskItem[0]; 
        while(lamp==1){
            Console.WriteLine("-------MENU-------");
            Console.WriteLine("1.Yeni tapshiriq elave et");
            Console.WriteLine("2.Tapshiriqlari goster");
            Console.WriteLine("3.Tapshirigi tamamla");
            Console.WriteLine("4.Tapshirigi sil");
            Console.WriteLine("5.Çixish et");
            int secim = Convert.ToInt32(Console.ReadLine());

            switch(secim)
            {
                case 1:
                    TaskManager.AddTask(ref tasks);
                    break;
                case 2:
                    TaskManager.ShowTasks(tasks);
                    break;
                case 3:
                    TaskManager.TaskStatusChanger(tasks);
                    break;
                case 4:
                    TaskManager.TaskRemover( ref tasks);
                    break;
                case 5:
                    lamp=0;
                    break;
                default:
                    System.Console.WriteLine("Duzgun secim et eeeeey gozel insan");
                    break;

            }

        }

    }
}
