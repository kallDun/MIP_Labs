using System.Linq;

namespace Lab_4
{
    class Task__4_2
    {
        private string code_A;
        private string code_B;
        private int d;

        public Task__4_2(string a, string b, int d)
        {
            this.code_A = a;
            this.code_B = b;
            this.d = d;
        }

        public int GetWeight() => CodeHelper.Sum(code_A, code_B).Where(x => x == '1').Count();

        public string[] GetCombinations() => CodeHelper.GenerateAllCombinationsByDistance(code_A, d);

        public string GetSum() => CodeHelper.Sum(code_A, code_B);
    }
}
