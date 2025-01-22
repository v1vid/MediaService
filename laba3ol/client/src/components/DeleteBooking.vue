<template>
    <div v-if="show" class="modal__shadow" @click.self="closeModal">
        <div class="modal">
            <div class="modal__close" @click="closeModal">&#10006;</div>
            <slot name="title">
                <h3 class="modal__title">Удаление</h3>
            </slot>
            <slot name="body">
                <div class="modal__content">
                    Вы действительно желаете удалить бронирование?
                </div>
            </slot>
            <slot name="footer">
                <div class="modal__footer">
                    <button class="modal__footer__delete__button" @click="deleteBooking">
                        Да
                    </button>
                    <button class="modal__footer__cancel__button" @click="closeModal">
                        Отмена
                    </button>
                </div>
            </slot>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        name: 'DeleteBooking',
        data() {
            return {
                show: false,
                bookingId: -1,
            }
        },
        methods: {
            closeModal () {
                this.show = false
            },
            async deleteBooking () {
                try {
                    console.log(axios.defaults.headers.common['Authorization']);
                    const response = await axios.delete(`http://127.0.0.1:8000/bookings/${this.bookingId}/delete/`);
                } catch (e) {
                    if (e.response) {
                        switch (e.response.status) {
                            case 401:
                                break;
                            default:
                        }
                    }
                } finally {
                    this.closeModal()
                    window.location.reload();
                }
            }
        }
    }
</script>

<style lang="scss">
   @import '../assets/modal.scss';
</style>