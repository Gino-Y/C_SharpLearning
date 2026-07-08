namespace CSharpLearning.Class02;

public class Lesson19
{
    public static void Run()
    {
        // 循环创建 101~111 共 11 间教室
        List<ClassRoom> classRooms = new List<ClassRoom>();
        for (int i = 101; i <= 111; i++)
        {
            classRooms.Add(new ClassRoom(i.ToString()));
        }
        ClassController classController = new ClassController(classRooms);
        classController.ClassOver();
    }
}

class ClassController
{
    private List<ClassRoom> classRooms = new List<ClassRoom>();

    public ClassController(List<ClassRoom> classRooms)
    {
        this.classRooms = classRooms;
    }

    public void ClassOver()
    {
        foreach (ClassRoom classRoom in classRooms)
        {
            classRoom.ClassOver();
        }
    }
}

class ClassRoom
{
    public string classRoomName;

    public ClassRoom(string classRoomName)
    {
        this.classRoomName = classRoomName;
    }

    public void ClassOver()
    {
        Console.WriteLine($"{classRoomName} 下课了");
    }
}