namespace Lab_4
{
    class Task__4_3
    {
        private string code_A;
        private int n;
        private int d;

        public Task__4_3(string a, int n, int d)
        {
            code_A = a;
            this.n = n;
            this.d = d;
        }

        public string[] GetCombinations() => CodeHelper.GenerateAllCombinationsByDistance(code_A, d);
    }
}
