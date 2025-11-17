public static double Calculate(string userInput)
{	
    var numbers = userInput.Split();   
    var initialAmount = double.Parse(numbers[0]);
    var annualInterestRate = double.Parse(numbers[1]);
    var monthsCount = int.Parse(numbers[2]);    
	
	  var monthlyInterestRate = annualInterestRate / (12 * 100);
    var growthFactor = 1 + monthlyInterestRate;
    var finalAmount = initialAmount * Math.Pow(growthFactor, monthsCount);   
    return finalAmount;
}
