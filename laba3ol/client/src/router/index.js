import {createRouter, createWebHistory} from "vue-router";
import Rooms from "@/components/RoomList.vue"
import Login from "@/components/Login.vue";
import Main from "@/components/Main.vue";
import Logout from "@/components/Logout.vue";
import Register from "@/components/Register.vue";
import BookingList from "@/components/BookingList.vue";

const routes = [  
   { path: '/rooms', component: Rooms },
   { path: '/login', component: Login },
   { path: '/register', component: Register },
   { path: '/', component: Main },
   { path: '/logout', component: Logout },
   { path: '/bookings', component: BookingList },

]

const router = createRouter({
   history: createWebHistory(), routes
})

export default router