function selectChair(obj) {
  
  switch (obj.getAttribute("aria-checked")){
    case "false":
      obj.setAttribute('aria-checked', "true");
      obj.style.background = "#307701";
      break;
    case "true":
      obj.setAttribute('aria-checked', "false");
      obj.style.background = "";
      break;
    }
}
