# NPaMM

NPaMM - Network Planning and Management Models - Модели сетевого планирования и управления
![Network Planning and Management Models](https://github.com/joylz-developer/NPaMM/blob/master/imgs/2020-06-01_22-11-46.png)

# Инструкция и описание
### Модели
Каждый круг(модель) можно передвигать и редактировать. 

Для добавления и редактирование моделей используйте соответсвующий блок
![Блок моделей](https://github.com/joylz-developer/NPaMM/blob/master/imgs/2020-06-01_22-11-46-model.png)

Чтобы можно было редактировать модель выделите одну из них.
Все модели, которые не имеют связи не будет использоваться во время рассчетов.

### Связи
Для добавления связей между моделями используйте соответсвующий блок
![Блок связей](https://github.com/joylz-developer/NPaMM/blob/master/imgs/2020-06-01_22-11-46-bind.png)

Чтобы связать модели выделите последовательно эти модели, укажите минимально и максимально время на выполнение и нажмите "Add bind". 
Во время выделения моделей можно отредактирвоать время. Для этого снова выделите модели и назначте новое время.
Для удаления связи между моделями нажмите "Remove bind".

### Расчеты
![Расчеты](https://github.com/joylz-developer/NPaMM/blob/master/imgs/2020-06-01_22-16-32.png)

Во время перехода на вкладку Calculations(Расчеты) будут произведены все рассчеты автоматически. Все найденые ошибки будут сообщены во всплывающем окне.

В блок "Info" будет добавлена обновленая информация о всех путях и о критическом пути после каждого перехода на вкладку.

Для того, чтобы оценить вероятность выполнения всего комплекса работ за X дней используйте блок "Probability of completion".

А для оценки максимально возможного срока выполнения всего комплекса работ с надежностью X%  используйте блок "Estimate the maximum possible time". Укажите вещественное число от 0-100.

Вся расчитанная информация будет выведена в инфо-блоке.
