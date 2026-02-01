<div align="center">

# Never Come Lab
> **전생했는데 또 대학원?!🧑‍🎓**

</div>



## 프로젝트 정보 
- 유니티, 3개월 / 4명
- 특징 : 맵퍼즐을 풀고, 몬스터를 피하거나 처치하여 스테이지들을 깨는 스토리 어드벤처 게임
- 만들래 10분 게임 콘테스트 출품작 
- [시연 영상](https://www.youtube.com/watch?v=q59HrhljNyg)
<table>
  <tr>
    <td><img src="NeverComeLab/Assets/Readme/Ingame1.png" alt="Ingame1" width="400"></td>
    <td><img src="NeverComeLab/Assets/Readme/Ingame2.png" alt="Ingame2" width="400"></td>
  </tr>
</table>

## 담당
### Client 
- 전반적인 플레이어 로직(이동, 피격, 무기) 
- 플랫폼(레버, 숨기 기능)
- 사운드
- 씬 재시작 기능 

## 파일 구조
```
📦NeverComeLab
 ┣ 📂Assets
 ┃ ┣ 📂Animations   # 캐릭터 및 사물 애니메이션 클립
 ┃ ┣ 📂Audio        # 배경음악 및 효과음 리소스
 ┃ ┣ 📂Images       # 게임 배경 및 UI 이미지 리소스
 ┃ ┣ 📂MonsterData  # 몬스터 스탯 정보 에셋
 ┃ ┣ 📂Prefabs      # 프리팹 (Player, Enemy, UI, Interactable Objects 등)
 ┃ ┣ 📂Scenes       # 게임 씬
 ┃ ┣ 📂Scripts      # 게임 로직
 ┃ ┃ ┣ 📂Audio          # 오디오 관리 및 효과 제어
 ┃ ┃ ┣ 📂Data           # 무기 데이터
 ┃ ┃ ┣ 📂DialogSystem   # 대화 시스템 및 카메라 줌인 연출
 ┃ ┃ ┣ 📂MainMenu       # 메인 화면 UI 및 버튼 로직
 ┃ ┃ ┣ 📂Monster        # 몬스터 AI, 센서, 투사체 로직 
 ┃ ┃ ┣ 📂NPC            # 상호작용 가능한 NPC 및 오브젝트 로직 
 ┃ ┃ ┣ 📂Stage(N)       # 각 스테이지별 기믹 및 매니저 스크립트 
 ┃ ┣ 📂Timeline     # 컷신 연출을 위한 타임라인
 ┗ 📂Design   # 기획 스케치 및 컨셉 자료
 ```



## 패턴흐름도
### 레버
![alt text](<NeverComeLab/Assets/Readme/lever_sequence_diagram.png>)




## 일화

### 싱글톤 패턴 남용

씬 전환시 싱글톤 게임매니저 내 오브젝트가 사라지는 문제가 발생함. 싱글톤 남용이 결합도를 높여 문제가 됨을 깨닫고 필요할 때만 사용해야함을 알게됌. 최고 레벨 상태나 전역 접근이 필요한 경우에만 싱글톤 적용하고, 그 외에는 직접 참조하도록 수정함.

### 레버의 확장성이 필요해짐

기존 레버는 하나의 벽만 제어해 기능 확장이 어려웠어서 여러 벽을 동시에 제어하고 다양한 동작을 지원하기 위해 메시지 기반 상호작용으로 리팩토링함. 동작 종류를 enum으로 분리하고 제어 대상을 리스트로 확장해 가독성과 재사용성을 높임.