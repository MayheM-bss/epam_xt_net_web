function charRemover(str) {
  var separators = [" ", "\t", "?", "!", ":", ";", ",", "."];
  var words = str.split(" ");
  var repeatedChars = [];
  var unrepeatedChars = [];
  var result;

  words.forEach((word) => {
    for (var i = 0; i <= word.length; i++) {
      if (
        repeatedChars.indexOf(word[i]) == -1 &&
        separators.indexOf(word[i]) == -1 &&
        word.indexOf(word[i]) != word.lastIndexOf(word[i])
      ) {
        repeatedChars.push(word[i]);
      }
    }
  });

  unrepeatedChars = str.split("").filter((symbol) => {
    return repeatedChars.indexOf(symbol) == -1;
  });

  result = unrepeatedChars.join("");
  console.log(result);
  return result;
}

charRemover("У попа была собака");
