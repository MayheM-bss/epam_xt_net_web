function charRemover(str) {
  var separators = [" ", "\t", "?", "!", ":", ";", ",", "."];
  var words = str.split(" ");
  var repeatedChars = [];

  words.forEach((word) => {
    for (let i = 0; i <= word.length; i++) {
      if (
        repeatedChars.indexOf(word[i]) == -1 &&
        separators.indexOf(word[i]) == -1 &&
        word.indexOf(word[i]) != word.lastIndexOf(word[i])
      ) {
        repeatedChars.push(word[i]);
      }
    }
  });

  var unrepeatedChars = str.split("").filter((symbol) => {
    return repeatedChars.indexOf(symbol) == -1;
  });

  var result = unrepeatedChars.join("");
  console.log(result);
  return result;
}

charRemover("У попа была собака");
