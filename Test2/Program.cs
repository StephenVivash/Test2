
using ValueSequencer;

Console.WriteLine("Hello .NET!");

Sequences.Initialise();
CHexagramValueSequencer hvsCurrent = new CHexagramValueSequencer(63);
CHexagramValueSequencer hvs = hvsCurrent;

for (int i = 0; i < 10; i++)
	Console.WriteLine("Current {0}", ((CHexagramValueSequencer)hvsCurrent.Next()).DescribeCast());

CLineValueSequencer.SetCurrentRatio(0);
CHexagramArray ha = new CHexagramArray();
ha.MultiCast(10000);
foreach (CHexagram h in ha.HexagramArray())
	if (h.Count > 0)
		Console.WriteLine($"{h.Count,4:D} {h.DescribeCast}");

Console.WriteLine("AddOne(1) = {0}", AddOne(1));
Console.WriteLine("AddOne(2) = {0}", AddOne(2));
Console.WriteLine("AddOne(3) = {0}", AddOne(3));

Console.WriteLine("Double(1) = {0}", Double(1));
Console.WriteLine("Double(2) = {0}", Double(2));
Console.WriteLine("Double(3) = {0}", Double(3));

int AddOne(int x) => x + 1;	

int Double(int x) => x * 2;