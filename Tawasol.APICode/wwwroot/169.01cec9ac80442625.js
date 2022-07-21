"use strict";(self.webpackChunkTawasol_SPA=self.webpackChunkTawasol_SPA||[]).push([[169],{9169:(ae,v,m)=>{m.r(v),m.d(v,{AuthModule:()=>oe});var p=m(9808),u=m(9706),e=m(5e3),f=m(1284),c=m(6850),g=m(7423);let U=(()=>{class r{constructor(o,t,i,s){this.active=o,this.auth=t,this.alert=i,this.route=s,this.email="",this.token=""}ngOnInit(){this.email=this.active.snapshot.queryParams.email,this.token=this.active.snapshot.queryParams.token}Confirme(){this.alert.loading("Confirming in ....",{duration:1e10,id:"closeLoading"});let o={email:this.email,token:this.token};null==o.email||null==o.token?(this.alert.close("closeLoading"),this.alert.info("Check inbox")):this.auth.ConfirmeEmail(o).subscribe(t=>{"pls create acount first"==t.message?(this.alert.close("closeLoading"),this.alert.warning(t.message),this.route.navigate(["/signup"])):(this.alert.close("closeLoading"),this.alert.success(t.message),this.route.navigate(["/login"]))})}}return r.\u0275fac=function(o){return new(o||r)(e.Y36(u.gz),e.Y36(f.e),e.Y36(c.jE),e.Y36(u.F0))},r.\u0275cmp=e.Xpm({type:r,selectors:[["app-confirmemail"]],decls:23,vars:1,consts:[[1,"vh-100","wh-100","bg-white","text-black"],[1,"row","h-100","w-100"],[1,"col-sm-6"],[1,"d-flex","w-100","h-100",2,"justify-content","center","align-items","center"],[1,"w-75","text-left"],[1,"main-color",2,"font-size","30px","font-weight","bolder"],[2,"font-size","60px"],[1,"text-muted"],[1,"w-75"],["mat-flat-button","","color","primary",1,"w-100",3,"click"]],template:function(o,t){1&o&&(e.TgZ(0,"div",0)(1,"div",1)(2,"div",2)(3,"div",3)(4,"div",4)(5,"h1",5)(6,"span",6),e._uU(7,"T"),e.qZA(),e._uU(8,"awasol"),e.qZA(),e.TgZ(9,"h2",7),e._uU(10,"Tawasol gives you the ability to connect with people and share what you want with them."),e.qZA()()()(),e.TgZ(11,"div",2)(12,"div",3)(13,"div")(14,"h1"),e._uU(15,"Confirm your email"),e.qZA(),e.TgZ(16,"p",8),e._uU(17,"Wellcom back your email "),e.TgZ(18,"strong"),e._uU(19),e.qZA(),e._uU(20," please confirme it"),e.qZA(),e.TgZ(21,"button",9),e.NdJ("click",function(){return t.Confirme()}),e._uU(22,"Confirm"),e.qZA()()()()()()),2&o&&(e.xp6(19),e.Oqu(t.email))},directives:[g.lW],styles:[""]}),r})();var n=m(3075),l=m(7322),_=m(7531),w=m(5245);function S(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Email is required"),e.qZA())}function y(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Email inValid"),e.qZA())}let P=(()=>{class r{constructor(o,t,i,s){this.fb=o,this.alert=t,this.auth=i,this.router=s}ngOnInit(){this.createForm()}createForm(){this.forgetFrom=this.fb.group({email:["",[n.kI.required,n.kI.email]]})}submit(o){this.alert.loading("Loading ...",{duration:1e10,id:"CloseLoading"}),this.auth.ForgetPass(o.value).subscribe(t=>{this.alert.close("CloseLoading"),"pls create account first ^_^ "==t.message?this.alert.warning(t.message):(this.alert.success(t.message),this.router.navigate(["/"]))})}}return r.\u0275fac=function(o){return new(o||r)(e.Y36(n.qu),e.Y36(c.jE),e.Y36(f.e),e.Y36(u.F0))},r.\u0275cmp=e.Xpm({type:r,selectors:[["app-forget-pass"]],decls:30,vars:4,consts:[[1,"vh-100","wh-100","bg-white","text-black"],[1,"row","h-100","w-100"],[1,"col-sm-6"],[1,"d-flex","w-100","h-100",2,"justify-content","center","align-items","center"],[1,"w-75","text-left"],[1,"main-color",2,"font-size","30px","font-weight","bolder"],[2,"font-size","60px"],[1,"text-muted"],[3,"formGroup","ngSubmit"],["appearance","fill",1,"w-100"],["formControlName","email","matInput","","placeholder","*Ex/ abc@abc.abc"],["matSuffix",""],[1,"fa-brands","fa-google"],[4,"ngIf"],["mat-flat-button","","color","primary",1,"w-100",3,"disabled"],[1,"m-auto",2,"width","60%"],["routerLink","/","mat-flat-button","","color","warn",1,"w-100"]],template:function(o,t){if(1&o&&(e.TgZ(0,"div",0)(1,"div",1)(2,"div",2)(3,"div",3)(4,"div",4)(5,"h1",5)(6,"span",6),e._uU(7,"T"),e.qZA(),e._uU(8,"awasol "),e.qZA(),e.TgZ(9,"h2",7),e._uU(10," Tawasol gives you the ability to connect with people and share what you want with them. "),e.qZA()()()(),e.TgZ(11,"div",2)(12,"div",3)(13,"div")(14,"form",8),e.NdJ("ngSubmit",function(){return t.submit(t.forgetFrom)}),e.TgZ(15,"mat-form-field",9)(16,"mat-label"),e._uU(17,"Email"),e.qZA(),e._UZ(18,"input",10),e.TgZ(19,"mat-icon",11),e._UZ(20,"i",12),e.qZA(),e.YNc(21,S,2,0,"mat-error",13),e.YNc(22,y,2,0,"mat-error",13),e.qZA(),e.TgZ(23,"button",14),e._uU(24," Done "),e.qZA()(),e.TgZ(25,"div",15),e._UZ(26,"hr"),e.qZA(),e.TgZ(27,"div")(28,"a",16),e._uU(29,"SignIn"),e.qZA()()()()()()()),2&o){let i,s;e.xp6(14),e.Q6J("formGroup",t.forgetFrom),e.xp6(7),e.Q6J("ngIf",null==(i=t.forgetFrom.get("email"))?null:i.hasError("required")),e.xp6(1),e.Q6J("ngIf",null==(s=t.forgetFrom.get("email"))?null:s.hasError("email")),e.xp6(1),e.Q6J("disabled",t.forgetFrom.invalid)}},directives:[n._Y,n.JL,n.sg,l.KE,l.hX,n.Fj,_.Nt,n.JJ,n.u,w.Hw,l.R9,p.O5,l.TO,g.lW,u.yS,g.zs],styles:[""]}),r})();function F(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Password is required"),e.qZA())}function I(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Min length 6"),e.qZA())}function J(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Password is required"),e.qZA())}function N(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Min length 6"),e.qZA())}function k(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1," Passwords should match "),e.qZA())}let Y=(()=>{class r{constructor(o,t,i,s,d){this.fb=o,this.alert=t,this.active=i,this.auth=s,this.router=d,this.hidePassword=!0,this.hideCPassword=!0}ngOnInit(){var o;this.email=this.active.snapshot.queryParams.email,this.token=null===(o=this.active.snapshot.queryParamMap.get("token"))||void 0===o?void 0:o.split(" ").join("%"),this.createForm()}createForm(){this.resetFrom=this.fb.group({password:["",[n.kI.required,n.kI.minLength(6)]],cpassword:["",[n.kI.required,n.kI.minLength(6)]]},{validators:r=>{var a,o;const t=null===(a=r.get("password"))||void 0===a?void 0:a.value,i=null===(o=r.get("cpassword"))||void 0===o?void 0:o.value;return t&&i&&t!==i?{passwordsDontMatch:!0}:null}})}submit(o){this.alert.loading("loading ...",{duration:1e9,id:"CloseLoading"});let t={email:this.email,token:this.token,password:o.value.password};null==t.email||null==t.token||null==t.password?(this.alert.close("CloseLoading"),this.alert.info("Check inbox")):this.auth.ResetPass(t).subscribe(i=>{this.alert.close("CloseLoading"),"Some thing Error"==i.message?this.alert.error(i.message):(this.alert.success(i.message),this.router.navigate(["/"]))})}}return r.\u0275fac=function(o){return new(o||r)(e.Y36(n.qu),e.Y36(c.jE),e.Y36(u.gz),e.Y36(f.e),e.Y36(u.F0))},r.\u0275cmp=e.Xpm({type:r,selectors:[["app-reset-pass"]],decls:39,vars:11,consts:[[1,"vh-100","wh-100","bg-white","text-black"],[1,"row","h-100","w-100"],[1,"col-sm-6"],[1,"d-flex","w-100","h-100",2,"justify-content","center","align-items","center"],[1,"w-75","text-left"],[1,"main-color",2,"font-size","30px","font-weight","bolder"],[2,"font-size","60px"],[1,"text-muted"],[1,"ms-auto",2,"width","93%",3,"formGroup","ngSubmit"],["appearance","fill",1,"w-100"],["formControlName","password","matInput","","placeholder","*Password",3,"type"],["matSuffix","",2,"cursor","pointer",3,"click"],[3,"ngClass"],[4,"ngIf"],["formControlName","cpassword","matInput","","placeholder","*Confirm Password",3,"type"],["mat-flat-button","","color","primary",1,"w-100",3,"disabled"],[1,"m-auto",2,"width","60%"],[1,"ms-auto",2,"width","93%"],["routerLink","/login","mat-flat-button","","color","warn",1,"w-100"]],template:function(o,t){if(1&o&&(e.TgZ(0,"div",0)(1,"div",1)(2,"div",2)(3,"div",3)(4,"div",4)(5,"h1",5)(6,"span",6),e._uU(7,"T"),e.qZA(),e._uU(8,"awasol "),e.qZA(),e.TgZ(9,"h2",7),e._uU(10," Tawasol gives you the ability to connect with people and share what you want with them. "),e.qZA()()()(),e.TgZ(11,"div",2)(12,"div",3)(13,"div")(14,"form",8),e.NdJ("ngSubmit",function(){return t.submit(t.resetFrom)}),e.TgZ(15,"mat-form-field",9)(16,"mat-label"),e._uU(17,"Password"),e.qZA(),e._UZ(18,"input",10),e.TgZ(19,"mat-icon",11),e.NdJ("click",function(){return t.hidePassword=!t.hidePassword}),e._UZ(20,"i",12),e.qZA(),e.YNc(21,F,2,0,"mat-error",13),e.YNc(22,I,2,0,"mat-error",13),e.qZA(),e.TgZ(23,"mat-form-field",9)(24,"mat-label"),e._uU(25,"Confirm Password"),e.qZA(),e._UZ(26,"input",14),e.TgZ(27,"mat-icon",11),e.NdJ("click",function(){return t.hideCPassword=!t.hideCPassword}),e._UZ(28,"i",12),e.qZA(),e.YNc(29,J,2,0,"mat-error",13),e.YNc(30,N,2,0,"mat-error",13),e.qZA(),e.YNc(31,k,2,0,"mat-error",13),e.TgZ(32,"button",15),e._uU(33," Done "),e.qZA()(),e.TgZ(34,"div",16),e._UZ(35,"hr"),e.qZA(),e.TgZ(36,"div",17)(37,"a",18),e._uU(38,"SignIn"),e.qZA()()()()()()()),2&o){let i,s,d,h;e.xp6(14),e.Q6J("formGroup",t.resetFrom),e.xp6(4),e.Q6J("type",t.hidePassword?"password":"text"),e.xp6(2),e.Q6J("ngClass",t.hidePassword?"fa-solid fa-eye":"fa-solid fa-eye-slash"),e.xp6(1),e.Q6J("ngIf",null==(i=t.resetFrom.get("password"))?null:i.hasError("required")),e.xp6(1),e.Q6J("ngIf",null==(s=t.resetFrom.get("password"))?null:s.hasError("minlength")),e.xp6(4),e.Q6J("type",t.hideCPassword?"password":"text"),e.xp6(2),e.Q6J("ngClass",t.hideCPassword?"fa-solid fa-eye":"fa-solid fa-eye-slash"),e.xp6(1),e.Q6J("ngIf",null==(d=t.resetFrom.get("cpassword"))?null:d.hasError("required")),e.xp6(1),e.Q6J("ngIf",null==(h=t.resetFrom.get("cpassword"))?null:h.hasError("minlength")),e.xp6(1),e.Q6J("ngIf",null==t.resetFrom.errors?null:t.resetFrom.errors.passwordsDontMatch),e.xp6(1),e.Q6J("disabled",t.resetFrom.invalid)}},directives:[n._Y,n.JL,n.sg,l.KE,l.hX,n.Fj,_.Nt,n.JJ,n.u,w.Hw,l.R9,p.mk,p.O5,l.TO,g.lW,u.yS,g.zs],styles:[""]}),r})();function E(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Email is required"),e.qZA())}function Q(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Email inValid"),e.qZA())}function L(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Password is required"),e.qZA())}let M=(()=>{class r{constructor(o,t,i,s){this.fb=o,this.auth=t,this.alert=i,this.router=s,this.hidePassword=!0}ngOnInit(){null!=this.auth.user.value&&this.router.navigate(["/pages"]),this.CreateForm()}login(o){this.alert.loading("Logining in ...",{duration:1e5,id:"closeLoading"}),this.auth.Login(o.value).subscribe(t=>{"success"!=t.message?(this.alert.error(t.message),this.alert.close("closeLoading")):(this.alert.success(`Wellcom ${t.fullName} ^_^`),localStorage.setItem("TawasolToken",t.token),this.auth.SaveUserData(),this.router.navigate(["/pages"]),this.alert.close("closeLoading"),o.reset())})}CreateForm(){this.signinFrom=this.fb.group({email:["",[n.kI.required,n.kI.email]],password:["",[n.kI.required]]})}}return r.\u0275fac=function(o){return new(o||r)(e.Y36(n.qu),e.Y36(f.e),e.Y36(c.jE),e.Y36(u.F0))},r.\u0275cmp=e.Xpm({type:r,selectors:[["app-signin"]],decls:40,vars:7,consts:[[1,"vh-100","wh-100","bg-white","text-black"],[1,"row","h-100","w-100"],[1,"col-sm-6"],[1,"d-flex","w-100","h-100",2,"justify-content","center","align-items","center"],[1,"w-75","text-left"],[1,"main-color",2,"font-size","30px","font-weight","bolder"],[2,"font-size","60px"],[1,"text-muted"],[1,"ms-auto",2,"width","95%",3,"formGroup","ngSubmit"],["appearance","fill",1,"w-100"],["formControlName","email","matInput","","placeholder","*Ex/ abc@abc.abc"],["matSuffix",""],[1,"fa-brands","fa-google"],[4,"ngIf"],["formControlName","password","matInput","","placeholder","*Password",3,"type"],["matSuffix","",2,"cursor","pointer",3,"click"],[3,"ngClass"],["mat-flat-button","","color","primary",1,"w-100",3,"disabled"],[1,"mt-3",2,"text-align","right"],["routerLink","/forgetpass",2,"text-decoration","none"],[1,"m-auto",2,"width","60%"],[1,"ms-auto",2,"width","95%"],["routerLink","/signup","mat-flat-button","","color","warn",1,"w-100"]],template:function(o,t){if(1&o&&(e.TgZ(0,"div",0)(1,"div",1)(2,"div",2)(3,"div",3)(4,"div",4)(5,"h1",5)(6,"span",6),e._uU(7,"T"),e.qZA(),e._uU(8,"awasol "),e.qZA(),e.TgZ(9,"h2",7),e._uU(10," Tawasol gives you the ability to connect with people and share what you want with them. "),e.qZA()()()(),e.TgZ(11,"div",2)(12,"div",3)(13,"div")(14,"form",8),e.NdJ("ngSubmit",function(){return t.login(t.signinFrom)}),e.TgZ(15,"mat-form-field",9)(16,"mat-label"),e._uU(17,"Email"),e.qZA(),e._UZ(18,"input",10),e.TgZ(19,"mat-icon",11),e._UZ(20,"i",12),e.qZA(),e.YNc(21,E,2,0,"mat-error",13),e.YNc(22,Q,2,0,"mat-error",13),e.qZA(),e.TgZ(23,"mat-form-field",9)(24,"mat-label"),e._uU(25,"Password"),e.qZA(),e._UZ(26,"input",14),e.TgZ(27,"mat-icon",15),e.NdJ("click",function(){return t.hidePassword=!t.hidePassword}),e._UZ(28,"i",16),e.qZA(),e.YNc(29,L,2,0,"mat-error",13),e.qZA(),e.TgZ(30,"button",17),e._uU(31," SignIn "),e.qZA(),e.TgZ(32,"div",18)(33,"a",19),e._uU(34,"forget password !?"),e.qZA()()(),e.TgZ(35,"div",20),e._UZ(36,"hr"),e.qZA(),e.TgZ(37,"div",21)(38,"a",22),e._uU(39,"SignUp"),e.qZA()()()()()()()),2&o){let i,s,d;e.xp6(14),e.Q6J("formGroup",t.signinFrom),e.xp6(7),e.Q6J("ngIf",null==(i=t.signinFrom.get("email"))?null:i.hasError("required")),e.xp6(1),e.Q6J("ngIf",null==(s=t.signinFrom.get("email"))?null:s.hasError("email")),e.xp6(4),e.Q6J("type",t.hidePassword?"password":"text"),e.xp6(2),e.Q6J("ngClass",t.hidePassword?"fa-solid fa-eye":"fa-solid fa-eye-slash"),e.xp6(1),e.Q6J("ngIf",null==(d=t.signinFrom.get("password"))?null:d.hasError("required")),e.xp6(1),e.Q6J("disabled",t.signinFrom.invalid)}},directives:[n._Y,n.JL,n.sg,l.KE,l.hX,n.Fj,_.Nt,n.JJ,n.u,w.Hw,l.R9,p.O5,l.TO,p.mk,g.lW,u.yS,g.zs],styles:[""]}),r})();var T=m(9814);function j(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"First Name is required"),e.qZA())}function z(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Last Name is required"),e.qZA())}function R(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Email is required"),e.qZA())}function O(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Please enter your gmail or outlook"),e.qZA())}function G(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Password is required"),e.qZA())}function X(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Min length 6"),e.qZA())}function D(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Password is required"),e.qZA())}function W(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Min length 6"),e.qZA())}function B(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1," Passwords should match "),e.qZA())}function K(r,a){1&r&&(e.TgZ(0,"mat-error"),e._uU(1,"Gender is required"),e.qZA())}const H=[{path:"",redirectTo:"login",pathMatch:"full"},{path:"login",component:M},{path:"signup",component:(()=>{class r{constructor(o,t,i,s){this.fb=o,this.router=t,this.auth=i,this.alert=s,this.hidePassword=!0,this.hideCPassword=!0}ngOnInit(){null!=this.auth.user.value&&this.router.navigate(["/pages"]),this.CreateForm()}Signup(o){this.alert.loading("Signing up in ...",{duration:1e5,id:"closeLoading"}),this.auth.Register({email:o.value.email,password:o.value.password,firstName:o.value.firstName,lastName:o.value.lastName,gender:"true"==o.value.gender}).subscribe(i=>{this.alert.close("closeLoading"),"success"==i.message?(this.alert.success(`You are Wellcom ${i.fullName} ^_^`),this.router.navigate(["/"]),o.reset()):this.alert.error(i.message)})}CreateForm(){this.SignupFrom=this.fb.group({email:["",[n.kI.required,n.kI.email,n.kI.pattern("^[A-Za-z0-9._%+-]{1,}@(gmail|GMAIL|outlook|OUTLOOK).(COM|com)$")]],password:["",[n.kI.required,n.kI.minLength(6)]],cpassword:["",[n.kI.required,n.kI.minLength(6)]],firstName:["",[n.kI.required]],lastName:["",[n.kI.required]],gender:[null,[n.kI.required]]},{validators:r=>{var a,o;const t=null===(a=r.get("password"))||void 0===a?void 0:a.value,i=null===(o=r.get("cpassword"))||void 0===o?void 0:o.value;return t&&i&&t!==i?{passwordsDontMatch:!0}:null}})}}return r.\u0275fac=function(o){return new(o||r)(e.Y36(n.qu),e.Y36(u.F0),e.Y36(f.e),e.Y36(c.jE))},r.\u0275cmp=e.Xpm({type:r,selectors:[["app-signup"]],decls:75,vars:16,consts:[[1,"vh-100","wh-100","bg-white","text-black"],[1,"row","h-100","w-100"],[1,"col-sm-6"],[1,"d-flex","w-100","h-100",2,"justify-content","center","align-items","center"],[1,"w-75","text-left"],[1,"main-color",2,"font-size","30px","font-weight","bolder"],[2,"font-size","60px"],[1,"text-muted"],[1,"ms-auto",2,"width","95%",3,"formGroup","ngSubmit"],[1,"row"],[1,"col-6"],["appearance","fill",1,"w-100"],["formControlName","firstName","matInput","","placeholder","*First Name"],["matSuffix",""],[1,"fa-solid","fa-user"],[4,"ngIf"],["formControlName","lastName","matInput","","placeholder","*Last Name"],["formControlName","email","matInput","","placeholder","*Ex/ abc@abc.abc"],[1,"fa-brands","fa-google"],["formControlName","password","matInput","","placeholder","*Password",3,"type"],["matSuffix","",2,"cursor","pointer",3,"click"],[3,"ngClass"],["formControlName","cpassword","matInput","","placeholder","*Confirm Password",3,"type"],[1,"pt-2","pb-4"],["formControlName","gender","aria-label","Select an option"],["value","true"],["value","false",1,"ms-3"],["mat-flat-button","","color","primary",1,"w-100",3,"disabled"],[1,"m-auto",2,"width","60%"],[1,"ms-auto",2,"width","95%"],["routerLink","/login","mat-flat-button","","color","warn",1,"w-100"]],template:function(o,t){if(1&o&&(e.TgZ(0,"div",0)(1,"div",1)(2,"div",2)(3,"div",3)(4,"div",4)(5,"h1",5)(6,"span",6),e._uU(7,"T"),e.qZA(),e._uU(8,"awasol"),e.qZA(),e.TgZ(9,"h2",7),e._uU(10,"Tawasol gives you the ability to connect with people and share what you want with them."),e.qZA()()()(),e.TgZ(11,"div",2)(12,"div",3)(13,"div")(14,"form",8),e.NdJ("ngSubmit",function(){return t.Signup(t.SignupFrom)}),e.TgZ(15,"div",9)(16,"div",10)(17,"mat-form-field",11)(18,"mat-label"),e._uU(19,"First Name"),e.qZA(),e._UZ(20,"input",12),e.TgZ(21,"mat-icon",13),e._UZ(22,"i",14),e.qZA(),e.YNc(23,j,2,0,"mat-error",15),e.qZA()(),e.TgZ(24,"div",10)(25,"mat-form-field",11)(26,"mat-label"),e._uU(27,"Last Name"),e.qZA(),e._UZ(28,"input",16),e.TgZ(29,"mat-icon",13),e._UZ(30,"i",14),e.qZA(),e.YNc(31,z,2,0,"mat-error",15),e.qZA()()(),e.TgZ(32,"mat-form-field",11)(33,"mat-label"),e._uU(34,"Email"),e.qZA(),e._UZ(35,"input",17),e.TgZ(36,"mat-icon",13),e._UZ(37,"i",18),e.qZA(),e.YNc(38,R,2,0,"mat-error",15),e.YNc(39,O,2,0,"mat-error",15),e.qZA(),e.TgZ(40,"div",9)(41,"div",10)(42,"mat-form-field",11)(43,"mat-label"),e._uU(44,"Password"),e.qZA(),e._UZ(45,"input",19),e.TgZ(46,"mat-icon",20),e.NdJ("click",function(){return t.hidePassword=!t.hidePassword}),e._UZ(47,"i",21),e.qZA(),e.YNc(48,G,2,0,"mat-error",15),e.YNc(49,X,2,0,"mat-error",15),e.qZA()(),e.TgZ(50,"div",10)(51,"mat-form-field",11)(52,"mat-label"),e._uU(53,"Confirm Password"),e.qZA(),e._UZ(54,"input",22),e.TgZ(55,"mat-icon",20),e.NdJ("click",function(){return t.hideCPassword=!t.hideCPassword}),e._UZ(56,"i",21),e.qZA(),e.YNc(57,D,2,0,"mat-error",15),e.YNc(58,W,2,0,"mat-error",15),e.qZA()()(),e.TgZ(59,"div"),e.YNc(60,B,2,0,"mat-error",15),e.qZA(),e.TgZ(61,"div",23)(62,"mat-radio-group",24)(63,"mat-radio-button",25),e._uU(64,"Male"),e.qZA(),e.TgZ(65,"mat-radio-button",26),e._uU(66,"Female"),e.qZA(),e.YNc(67,K,2,0,"mat-error",15),e.qZA()(),e.TgZ(68,"button",27),e._uU(69,"SignUp"),e.qZA()(),e.TgZ(70,"div",28),e._UZ(71,"hr"),e.qZA(),e.TgZ(72,"div",29)(73,"a",30),e._uU(74,"SignIn"),e.qZA()()()()()()()),2&o){let i,s,d,h,q,C,b,A,Z;e.xp6(14),e.Q6J("formGroup",t.SignupFrom),e.xp6(9),e.Q6J("ngIf",null==(i=t.SignupFrom.get("firstName"))?null:i.hasError("required")),e.xp6(8),e.Q6J("ngIf",null==(s=t.SignupFrom.get("lastName"))?null:s.hasError("required")),e.xp6(7),e.Q6J("ngIf",null==(d=t.SignupFrom.get("email"))?null:d.hasError("required")),e.xp6(1),e.Q6J("ngIf",null==(h=t.SignupFrom.get("email"))?null:h.hasError("pattern")),e.xp6(6),e.Q6J("type",t.hidePassword?"password":"text"),e.xp6(2),e.Q6J("ngClass",t.hidePassword?"fa-solid fa-eye":"fa-solid fa-eye-slash"),e.xp6(1),e.Q6J("ngIf",null==(q=t.SignupFrom.get("password"))?null:q.hasError("required")),e.xp6(1),e.Q6J("ngIf",null==(C=t.SignupFrom.get("password"))?null:C.hasError("minlength")),e.xp6(5),e.Q6J("type",t.hideCPassword?"password":"text"),e.xp6(2),e.Q6J("ngClass",t.hideCPassword?"fa-solid fa-eye":"fa-solid fa-eye-slash"),e.xp6(1),e.Q6J("ngIf",null==(b=t.SignupFrom.get("cpassword"))?null:b.hasError("required")),e.xp6(1),e.Q6J("ngIf",null==(A=t.SignupFrom.get("cpassword"))?null:A.hasError("minlength")),e.xp6(2),e.Q6J("ngIf",null==t.SignupFrom.errors?null:t.SignupFrom.errors.passwordsDontMatch),e.xp6(7),e.Q6J("ngIf",(null==(Z=t.SignupFrom.get("gender"))?null:Z.hasError("required"))&&(null==(Z=t.SignupFrom.get("gender"))?null:Z.touched)),e.xp6(1),e.Q6J("disabled",t.SignupFrom.invalid)}},directives:[n._Y,n.JL,n.sg,l.KE,l.hX,n.Fj,_.Nt,n.JJ,n.u,w.Hw,l.R9,p.O5,l.TO,p.mk,T.VQ,T.U0,g.lW,u.yS,g.zs],styles:[""]}),r})()},{path:"confirmemail",component:U},{path:"forgetpass",component:P},{path:"resetpass",component:Y}];let $=(()=>{class r{}return r.\u0275fac=function(o){return new(o||r)},r.\u0275mod=e.oAB({type:r}),r.\u0275inj=e.cJS({imports:[[u.Bz.forChild(H)],u.Bz]}),r})();var ee=m(2907),te=m(4466);let re=(()=>{class r{}return r.\u0275fac=function(o){return new(o||r)},r.\u0275mod=e.oAB({type:r}),r.\u0275inj=e.cJS({imports:[[p.ez]]}),r})(),oe=(()=>{class r{}return r.\u0275fac=function(o){return new(o||r)},r.\u0275mod=e.oAB({type:r}),r.\u0275inj=e.cJS({imports:[[p.ez,$,ee.q,te.m,re]]}),r})()}}]);