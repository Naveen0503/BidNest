const variable ={
  Base_Api_Url:"https://localhost:7234/",
  Bearer_Token:sessionStorage.getItem('token'),
  UserName:sessionStorage.getItem('username'),
  isuserloggedin: sessionStorage.getItem('token') != null ? true : false
};

export default variable;