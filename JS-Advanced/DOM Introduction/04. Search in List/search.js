function search() {
   let townList = document.querySelectorAll("li");
   let searchText = document.getElementById("searchText").value;
   let result = document.getElementById("result");

   for(let i = 0; i < townList.length; i++){
      townList[i].style.fontWeight = "normal";
      townList[i].style.textDecoration = "none";
   }

   let count = 0;
   for(let i = 0; i < townList.length; i++){
      if(townList[i].textContent.includes(searchText)) {
         townList[i].style.fontWeight = "bold";
         townList[i].style.textDecoration = "underline";
         count++;
      }
   }

   result.textContent = `${count} matches found`;
}

