function mathCalculator(str) {
  var regex = /(\d+\.\d+)|(\d+)|(\+|\-|\/|\*|\=)/g;
  var items = str.match(regex);
  var result = parseFloat(items[0]);

  for (let i = 1; i <= items.length; i++) {
    switch (items[i]) {
      case "+":
        {
          result += parseFloat(items[i + 1]);
        }
        break;

      case "-":
        {
          result -= parseFloat(items[i + 1]);
        }
        break;

      case "*":
        {
          result *= parseFloat(items[i + 1]);
        }
        break;

      case "/":
        {
          result /= parseFloat(items[i + 1]);
        }
        break;

      case "=":
        {
          result = result.toFixed(2);
          console.log(result);
        }
        break;
    }
  }
}

mathCalculator("3.5 +4*10-5.3 /5 =");
