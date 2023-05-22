import { Padding } from "@mui/icons-material";
import { Box, Typography, useTheme } from "@mui/material";
import FlexBetween from "components/FlexBetween";

const IconCard = ({ text, size = "150px" }) => {
  const theme = useTheme();
  const neutralMain = theme.palette.neutral.mediumMain;
  const neutral = theme.palette.neutral.light;
  const neutralDark = theme.palette.neutral.dark;
  const dark = theme.palette.neutral.dark;
  const background = theme.palette.background.default;
  const primaryLight = theme.palette.primary.light;
  const primaryMain = theme.palette.primary.main;
  const alt = theme.palette.background.alt;

  return (
    <Box
      backgroundColor={background}
      width="80%"
      paddingX="10px"
      height={"30px"}
      gap={"0.4rem"}
      justifyContent={"center"}
      display="flex"
      alignItems={"center"}
      border={`1px ${neutralMain} solid`}
      borderRadius={2}
      sx={{ "&:hover": { cursor: "pointer", opacity:0.7, } }}
    >
      <img
        width={"15px"}
        height={"15px"}
        style={{ objectFit: "cover" }}
        alt="user"
        src="https://images.emojiterra.com/twitter/v13.1/512px/1f916.png"
      />
      <Typography fontSize="13px" color={dark}>{text}</Typography>
    </Box>
  );
};
export default IconCard;
