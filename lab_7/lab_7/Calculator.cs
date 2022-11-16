namespace lab_7
{
    public class Calculator
    {
        private static char[] operations = { '+', '-', '*', '/' };

        public static int calculate(int a, int b, char operation)
        {
            
            if (!operations.Contains(operation))
            {
                throw new Exception("wrong operation");
            }

            return defineMethodAndCalculate(a, b, operation);
        }

        public static int calculate(int a, int b, string operation)
        {
            if (operation.Length != 1)
            {
                throw new Exception("wrong operation");
            }

            if (!operations.Contains(operation[0]))
            {
                throw new Exception("wrong operation");
            }

            return defineMethodAndCalculate(a, b, operation[0]);
        }

        public static int calculate(string str)
        {
            var operandsStr = str.Split(operations);
            if (operandsStr.Length != 2)
            {
                throw new Exception("not valid count of arguments");
            }

            var operation = str.FirstOrDefault(x => string.Join("", operations).Contains(x), default);
            if (operation == default)
            {
                throw new Exception("wrong operation");
            }

            var operands = strToInt(operandsStr);

            return defineMethodAndCalculate(operands[0], operands[1], operation);
        }

        private static int defineMethodAndCalculate(int a, int b, char operation)
        {
            switch (operation)
            {
                case '+':
                    return sum(a, b);
                case '-':
                    return min(a, b);
                case '*':
                    return mul(a, b);
                case '/':
                    return div(a, b);
            }

            throw new Exception("don't fuck with me");
        }

        private static int[] strToInt(string[] array)
        {
            int[] result = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                result[i] = Convert.ToInt32(array[i]);
            }

            return result;
        }

        private static int sum(int a, int b)
        {
            return a + b;
        }

        private static int min(int a, int b)
        {
            return a - b;
        }

        private static int mul(int a, int b)
        {
            return a * b;
        }

        private static int div(int a, int b)
        {
            return a / b;
        }
    }
}
