<template>
    <Base/>
    <DeleteBooking ref="del"/>
    <UpdateBooking ref="upt"/>
    <div v-if="this.user" class="booking__history__container">
    <h1>История бронирований</h1>
    <table class="booking__table">
        <thead>
            <tr>
                <th>ID</th>
                <th>Номер</th>
                <th>Дата бронирования</th>
                <th>Статус</th>
                <th>Оплата</th>
                <th>Действия</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="booking in bookings" :key="booking.id">
                <td>{{ booking.id }}</td>
                <td>{{ booking.room }}</td>
                <td>{{ booking.booking_date }}</td>
                <td>{{ booking.state }}</td>
                <td>{{ booking.payment_status }}</td>
                <td v-if="booking.state != 'finished'">
                    <a class="action__button delete__button" @click="showModalDelete(booking.id)">удалить</a> 
                    <a class="action__button edit__button" @click="showModalUpdate(booking.id)">редактировать</a> 
                </td>
                <td v-if="booking.state == 'finished'"> нельзя внести изменения </td>
            </tr>
        </tbody>
    </table>
    </div>
</template>

<script>
    import Base from '@/components/Base.vue';
    import DeleteBooking from '@/components/DeleteBooking.vue';
    import UpdateBooking from '@/components/UpdateBooking.vue';
    import axios from 'axios';

    export default {
        name: 'BookingList',
        components: {
            Base, DeleteBooking, UpdateBooking
        },
        data() {
            return {
                bookings: [],
                user: {}
            }
        },
        methods: {
            showModalDelete: function (id) {
                this.$refs.del.show = true
                this.$refs.del.bookingId = id
            },
            showModalUpdate: function (id) {
                this.$refs.upt.show = true
                this.$refs.upt.bookingId = id
            },
            async fetchUserBookings () {
                this.user = JSON.parse(localStorage.getItem('user'));
                try {
                    const response = await axios.get(`http://127.0.0.1:8000/users/${this.user.id}/`);
                    this.bookings = response.data.bookings;
                    this.bookings.forEach(async (booking) => {
                        const room_resp = await axios.get(`http://127.0.0.1:8000/rooms/${booking.room}/`);
                        booking.room = room_resp.data.number;
                    });
                    console.log(this.bookings);
                } catch (e) {
                    if (e.response) {
                        switch (e.response.status) {
                            case 401:
                                this.user = {};
                                break;
                            default:
                        }
                    }
                }
            }
        }, 
        mounted() {
            this.fetchUserBookings()
        }
    }
</script>

<style>
    .booking__history__container {
        max-width: 1200px;
        margin: 0 auto;
        padding: 2rem;
        background-color: #f9f9f9;
        border-radius: 8px;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    }

    h1 {
        text-align: center;
        margin-bottom: 1.5rem;
    }

    .booking__table {
        width: 100%;
        border-collapse: collapse;
        margin-bottom: 1.5rem;
    }

    .booking__table th, .booking__table td {
        padding: 0.75rem;
        text-align: left;
        border: 1px solid #ddd;
    }

    .booking__table th {
        background-color: #007bff;
        color: white;
    }

    .booking__table tr:nth-child(even) {
        background-color: #f2f2f2;
    }

    .booking__table tr:hover {
        background-color: #ddd;
    }

    .booking__table td {
        font-size: 0.9rem;
    }

    .action__button {
        padding: 8px 12px;
        margin-right: 5px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        font-size: 14px;
        transition: background-color 0.3s ease;
    }

    .edit__button {
        background-color: #3498db;
        color: white;
    }

    .edit__button:hover {
        background-color: #2980b9; 
    }

    .delete__button {
        background-color: #e74c3c;
        color: white;
    }

    .delete__button:hover {
        background-color: #c0392b; 
    }
</style>