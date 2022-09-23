function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searchText = document.getElementById("searchField").value;
      let tableCells = document.querySelectorAll("tbody tr td");
      
      for(let i = 0; i < tableCells.length; i++) {
         tableCells[i].parentElement.classList.remove("select");
      }

      for(let i = 0; i < tableCells.length; i++) {
         if(tableCells[i].textContent.includes(searchText)) {
            tableCells[i].parentElement.classList.add("select");
         }
      }
   }
}