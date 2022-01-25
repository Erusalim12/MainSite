 <template>
 <div class="ms-schedule-daily">
     <div class="card">
         <div class="card-header">{{dailyRasp.Day}}</div>
             <div class="card-content">
             
             </div>
   <button class="btn" @click="sendDataToParent"> отправить данные родительскому объекту</button>
     </div>
 </div>
 </template>

 <script> 
 export default{
     name: "ms-schedule-daily",

     props:{
         dailyRasp:{
             type:Object,
             default(){
                 return{}
             }
         }
     },
     methods:{
         sendDataToParent(){
             this.$emit('sendArticle',this.dailyRasp.Name);
         }
     }
 };
 </script>
 