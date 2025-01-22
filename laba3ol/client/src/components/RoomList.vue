<template>
    <Base />
    <Booking :show_list="true" ref="create" @update-state="showList"/>
    <h1 v-if="show_list" style="text-align: center;">Список номеров</h1>
    <div v-if="show_list" class="rooms__container">
        <div class="room__card" v-for="room in paginated">
            <div><span style="font-size: large; font-weight: bold;">Номер {{ room.number }}</span></div>
            <div><span>Площадь: {{ room.area }} м^2</span></div>
            <div><span>Стоимость: {{ room.room_type.prices[0].day_price }} $ / сутки</span></div>
            <div v-show="room.is_occupied">
                <span style="color: #E40066;">Занят на данный момент</span> <br>
                <button class="book__button"  @click="showBooking(room)">Забронировать</button>
            </div>
            <div v-show="!room.is_occupied">
                <span style="color: green;">Свободен</span> <br>
                <button class="book__button" @click="showBooking(room)">Забронировать</button>
            </div>
        </div>
    </div>
    <div v-if="show_list" class="pag__btns">
        <label>Страница {{ page+1 }} из {{ max_page+1 }}</label>
        <button v-if="page==0" disabled @click="prev()">Назад</button>
        <button v-else @click="prev()">Назад</button>
        <button v-if="page==max_page" disabled @click="next()">Вперед</button>
        <button v-else @click="next()">Вперед</button>
    </div>
</template>

<script>
    import axios from "axios";
    import Base from '@/components/Base.vue'
    import Booking from "@/components/Booking.vue";
    
    export default {
        components: {
            Base, Booking
        },
        name: "Rooms",
        data() {
            return {
                all_rooms: [],
                paginated: [],
                page: 0,
                max_page: Number,
                rooms_per_page: 6,
                selected_room: "",
                show_list: true,
            }
        },
        methods: {
            showBooking: function (room) {
                const user = JSON.parse(localStorage.getItem('user'));
                if (user) {
                    this.$refs.create.number = room.number
                    this.$refs.create.show = true
                    this.$refs.create.booking.room = room.id
                    this.show_list = false
                } else {
                    this.$router.push('/login');
                }
                
            },
            showList() {
                this.$refs.create.show = false
                this.show_list = true
            },
            paginate() {
                let start = this.rooms_per_page * this.page
                let end = Math.min(start + this.rooms_per_page, this.all_rooms.length)
                this.paginated = this.all_rooms.slice(start, end)
            },
            next() {
                this.page++
                this.paginate()
            },
            prev() {
                if (this.page > 0)
                    this.page--
                this.paginate()
            },
            async fetchRoomList () {
                try {
                    const response = await axios.get('http://127.0.0.1:8000/rooms/list/');
                    this.all_rooms = response.data
                    this.max_page =  Math.round(this.all_rooms.length / this.rooms_per_page)
                    this.paginate()
                } catch (e) {
                    if (e.response) {
                        switch (e.response.status) {
                            case 404:
                                break;
                            default:
                                alert('Ошибка ответа!');
                        } 
                    } else if (e.request) {
                        alert('Ошибка запроса!');
                    }
                }
            }
        },
        mounted() {
            this.fetchRoomList() 
        }
    }
</script>

<style>
    .rooms__container {
        display: grid;
        grid-template-columns: repeat(3, 1fr);
        justify-content: center;
        max-width: 80%;
        margin: auto;
        column-gap: 1em;    
        row-gap: 1em;
    }

    .room__card {
        background-color: #fff;
        border-radius: 10px;
        padding: 10%;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        overflow: hidden;
        max-width: 100%;
        transition: transform 0.3s;
    }

    .room__card div {
        margin-top: 5px;
        margin-bottom: 5px;
    }

    .room__card:hover {
        transform: translateY(-5px);
    }

    .book__button {
        background-color: #1C7C54;
        color: white;
        border: none;
        margin-top: 10px;
        padding: 10px 15px;
        width: 100%;
        font-size: 16px;
        border-radius: 5px;
        cursor: pointer;
        transition: background-color 0.3s;
    }

    .pag__btns {
        margin-top: 5%;
        display: flex;
        gap: 10px;
        justify-content: center;
    }
</style>