<template>
    <div v-if="show" class="modal__shadow" @click.self="closeModal">
        <div class="modal">
            <div class="modal__close" @click="closeModal">&#10006;</div>
                <h2>Редактирование брони</h2>
                <label v-if="this.error_msg" style="color: red;">{{ this.error_msg }}</label>
                <form @submit.prevent="updateBooking">
                    <div class="form__group">
                        <label for="beginDate">Запланированная дата начала</label>
                        <input type="date" id="__username" v-model="beginDate" required />
                    </div>
                    <div class="form__group">
                        <label for="endDate">Запланированная дата окончания</label>
                        <input type="date" id="__checkInDate" v-model="endDate" required />
                    </div>
                    <button type="submit" class="submit__button">Редактировать</button>
                </form>
        </div> 
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        name: 'UpdateBooking',
        data() {
            return {
                beginDate: '',
                endDate: '',
                show: false,
                bookingId: Number,
                error_msg: '',
            }
        },
        methods: {
            closeModal () {
                this.show = false
            },
            async updateBooking () {
                try {
                    console.log(axios.defaults.headers.common['Authorization']);
                    const response = await axios.patch(`http://127.0.0.1:8000/bookings/${this.bookingId}/update/`, {
                        planned_begin_date: this.beginDate,
                        planned_end_date: this.endDate,
                    });
                    this.closeModal();
                    window.location.reload();
                } catch (e) {
                    if (e.response) {
                        switch (e.response.status) {
                            case 401:
                                break;
                            case 400:
                                this.error_msg = e.response.data['message']
                            default:
                        }
                    }
                }
            }
        } 
    }
</script>

<style>
    @import '../assets/modal.scss';
    @import '../assets/booking.css';
    
</style>